using IsSystem.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Reservation.Service.ResponseProviders.Tables.Commands.Create;
using Reservation.Service.ResponseProviders.Tables.Commands.Update;
using Reservation.Service.ResponseProviders.Tables.Queries.GetById;
using Reservation.Service.ResponseProviders.Tables.Queries.GetList;

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetListTableQuery() { PageRequest = pageRequest };
            return Ok(value: await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTableCommand createTableCommand)
        {
            return Ok(value: await Mediator.Send(createTableCommand));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            GetTableQuery getQuery = new() { Id = id };
            return Ok(value: await Mediator?.Send(getQuery));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTableCommand updateTableCommand)
        {
            return Ok(value: await Mediator.Send(updateTableCommand));
        }
    }
}
