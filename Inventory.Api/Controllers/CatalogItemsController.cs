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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> List(int id)
        {
            var catalogItem = await _mediator.Send(new CatalogItemQuery()
            {
                Id = id
            });
            if (catalogItem != null)
            {
                return Ok(catalogItem);
            }
            return BadRequest("Record not exist!");
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCatalogItemDto dto)
        {
            var command = new CreateCatalogItemCommand()
            {
                Name = dto.Name,
                PriceAmount = dto.PriceAmount,
                PriceCurrency = dto.PriceCurrency,
                ProviderId = dto.ProviderId
            };

            var createdId = await _mediator.Send(command);
            if(createdId != -1)
            {
                return Ok(new
                {
                    CreatedId = createdId
                });
            }
            return BadRequest("Provider not found!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCatalogItemDto dto)
        {
            var command = new UpdateCatalogItemCommand()
            {
                Id = dto.Id,
                Name = dto.Name,
                PriceAmount = dto.PriceAmount,
                PriceCurrency = dto.PriceCurrency,
                ProviderId = dto.ProviderId
            };
            var updatedId = await _mediator.Send(command);
            if(updatedId != -1)
            {
                return Ok(new
                {
                    UpdatedId = updatedId
                });
            }
            return BadRequest("Provider not found!");
        }
        
        [HttpPut("updateProvider")]
        public async Task<IActionResult> UpdateCatalogProvider(UpdateProviderCatalogItemDto dto)
        {
            var command = new UpdateProviderCatalogItemCommand()
            {
                Id = dto.Id,
                ProviderId = dto.ProviderId
            };
            var updatedId = await _mediator.Send(command);
            return Ok(new
            {
                UpdatedId = updatedId
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var command = new RemoveCatalogItemCommand()
            {
                Id = id
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}