using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuoteCalculator.Source.Domain.UseCases.ApplyLoan;
using QuoteCalculator.Source.Domain.UseCases.CalculateQuote;
using QuoteCalculator.Source.Domain.UseCases.GetAllProducts;
using System.Threading.Tasks;

namespace QuoteCalculator.Source.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Api : ControllerBase
    {
        private IMediator mediator;

        public Api(IMediator mediator) => this.mediator = mediator;

        [HttpPost("Calculate")]
        public async Task<ActionResult> Calculate([FromBody] CalculateQuoteDto dto)
        {
            var result = await mediator.Send(new CalculateQuoteCommand(dto));

            return Ok(result);
        }

        [HttpPost("Apply")]
        public async Task<ActionResult> Apply([FromBody] ApplyLoanDto dto)
        {
            var result = await mediator.Send(new ApplyLoanCommand(dto));

            return Ok(result);
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            var result = await mediator.Send(new GetAllProductsQuery());

            return Ok(result);
        }
    }
}
