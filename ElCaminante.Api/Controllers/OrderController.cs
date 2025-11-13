using ElCaminante.Application.Features.Order.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElCaminante.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (command == null)
                return BadRequest();

            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateOrder), new { id = orderId }, new { orderId });
        }
    }
}
