using IsSystem.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Reservation.Service.ResponseProviders.Customers.Commands.Create;
using Reservation.Service.ResponseProviders.Customers.Commands.Update;
using Reservation.Service.ResponseProviders.Customers.Queries.GetById;
using Reservation.Service.ResponseProviders.Customers.Queries.GetList;

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetListCustomerQuery() { PageRequest = pageRequest };
            return Ok(value: await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            return Ok(value: await Mediator.Send(createCustomerCommand));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            GetCustomerQuery getQuery = new() { Id = id };
            return Ok(value: await Mediator?.Send(getQuery));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            return Ok(value: await Mediator.Send(updateCustomerCommand));
        }
    }
}
