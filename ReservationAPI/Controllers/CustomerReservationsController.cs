using IsSystem.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create;
using Reservation.Service.ResponseProviders.CustomerReservations.Commands.Update;
using Reservation.Service.ResponseProviders.CustomerReservations.Queries.GetById;
using Reservation.Service.ResponseProviders.CustomerReservations.Queries.GetList;

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReservationsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCustomerReservationListQuery() { PageRequest = pageRequest };
            return Ok(value: await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerReservationCommand createCustomerReservationCommand)
        {
            return Ok(value: await Mediator.Send(createCustomerReservationCommand));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            GetCustomerReservationQuery getQuery = new() { Id = id };
            return Ok(value: await Mediator?.Send(getQuery));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerReservationCommand updateCustomerReservationCommand)
        {
            return Ok(value: await Mediator.Send(updateCustomerReservationCommand));
        }
    }
}
