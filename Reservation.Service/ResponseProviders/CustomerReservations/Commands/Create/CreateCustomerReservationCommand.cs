using AutoMapper;
using IsSystem.Application.Tools.Mail;
using MediatR;
using Microsoft.Extensions.Configuration;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.CustomerReservations.Constants;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;
using Reservation.Service.ResponseProviders.CustomerReservations.Rules;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create
{
    public class CreateCustomerReservationCommand: IRequest<ReservationResultDto>
    {
        public required CustomerReservationDto CustomerReservation { get; set; }

        public class CreateCustomerReservationCommandHandler : IRequestHandler<CreateCustomerReservationCommand, ReservationResultDto>
        {
            private readonly ICustomerReservationRepository _repository;
            private readonly IMapper _mapper;
            private readonly TableAvailableRule _tableAvailableRule;
            private readonly ICustomerRepository _customerRepository;
            private readonly CheckCustomerExistRule _checkCustomerExistRule;
            private readonly IMailSender _mailSender;
            private readonly IConfiguration _configuration;

            public CreateCustomerReservationCommandHandler(ICustomerReservationRepository repository, IMapper mapper, 
                TableAvailableRule tableAvailableRule, ICustomerRepository customerRepository,
                CheckCustomerExistRule checkCustomerExistRule, IMailSender mailSender, IConfiguration configuration)
            {
                _repository = repository;
                _mapper = mapper;
                _tableAvailableRule = tableAvailableRule;
                _customerRepository = customerRepository;
                _checkCustomerExistRule = checkCustomerExistRule;
                _mailSender = mailSender;
                _configuration = configuration;
            }
            public async Task<ReservationResultDto> Handle(CreateCustomerReservationCommand request, CancellationToken cancellationToken)
            {
                await _tableAvailableRule.TableMustBeAvailable(request.CustomerReservation); // iş kuralı (reservasyon için uygun masa ve zaman seçilip seçilmediği kontrolü
                //eğer seçilmemişse global hata yönetimi ile status 400 kodlu bilgi mesajı döner

                Customer? customer; // istek yapan musteri daha once var mı kontrolu
                if(await _checkCustomerExistRule.CheckCustomerExist(request.CustomerReservation.CustomerDto) != null)
                {
                    customer = await _checkCustomerExistRule.CheckCustomerExist(request.CustomerReservation.CustomerDto);
                }
                else
                {
                    customer = await _customerRepository.AddAsync(_mapper.Map<Customer>(request.CustomerReservation.CustomerDto));
                }

                var reservation = new CustomerReservation()
                {
                    CreatedAt = DateTime.UtcNow,
                    CustomerId = customer!.Id,
                    GuestCount = request.CustomerReservation.GuestCount,
                    ReservationStartDate = request.CustomerReservation.ReservationStartDate,
                    ReservationEndDate = request.CustomerReservation.ReservationEndDate,
                    TableId = request.CustomerReservation.TableDto.Id
                };

                _ = await _repository.AddAsync(_mapper.Map<CustomerReservation>(reservation));

                var result = new ReservationResultDto()
                {
                    CustomerEmail = customer.Email,
                    CustomerName = customer.Name,
                    CustomerSurname = customer.Surname,
                    GuestCount = request.CustomerReservation.GuestCount,
                    ReservationEndDate = request.CustomerReservation.ReservationEndDate,
                    ReservationStartDate = request.CustomerReservation.ReservationStartDate,
                    TableName = request.CustomerReservation.TableDto.TableName
                };

                string mailBody = String.Format(ReservationMessages.MailBody, customer.Name, customer.Surname, result.ReservationStartDate.ToString(), result.ReservationEndDate.ToString(), result.TableName);

                var mailModel = new MailModel()
                {
                    Body = mailBody,
                    EnableSsl = true,
                    IsBodyHtml = true,
                    Recipient = customer.Email,
                    Password = _configuration.GetSection("MailPassword").Value!, 
                    Sender = _configuration.GetSection("MailSender").Value!,
                    SenderDisplayName = _configuration.GetSection("MailSenderDisplayName").Value!,
                    SmtpHost = _configuration.GetSection("SmtpHost").Value!,
                    SmtpPort = int.Parse(_configuration.GetSection("SmtpPort").Value!),
                    Subject = "Reservasyon",
                    Username = _configuration.GetSection("MailUsername").Value!,
                };

                _mailSender.SendMail(mailModel);  // bilgi maili gonderilir
                

                return result;
            }
        }
    }
}
