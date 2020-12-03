using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Api.Dtos;
using Inventory.Api.Queries;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CatalogItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCatalogItemDto dto)
        {
            var command = new CreateCatalogItemCommand()
            {
                Name = dto.Name,
                PriceAmount = dto.PriceAmount,
                PriceCurrency = dto.PriceCurrency
            };

            var createdId = await _mediator.Send(command);
            return Ok(new
            {
                CreatedId = createdId
            });
        }

        [HttpGet]
        public async Task<IActionResult> List(int skip, int take)
        {
            var list = await _mediator.Send(new ListCatalogItemQuery()
            {
                Skip = skip,
                Take = take
            });

            return Ok(list);
        }
    }
}