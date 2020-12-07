using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Api.Dtos;
using Inventory.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController, Route("Api/[controller]")]
    public class CatalogProviderController: ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogProviderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var list = await _mediator.Send(new ListCatalogProviderQuery()
            {
                Skip = skip,
                Take = take
            });

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> List(int id)
        {
            var catalogItem = await _mediator.Send(new CatalogProviderQuery()
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
        public async Task<IActionResult> Create(CreateCatalogProviderDto dto)
        {
            var command = new CreateCatalogProviderCommand()
            {
                Name = dto.Name,
                City = dto.City,
                AddressLine = dto.AddressLine,
            };
            var createdId = await _mediator.Send(command);
            return Ok(new
            {
                CreatedId = createdId
            });
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCatalogProviderDto dto)
        {
            var command = new UpdateCatalogProviderCommand()
            {
                Id = dto.Id,
                City = dto.City,
                Name = dto.Name,
                AddressLine = dto.AddressLine,
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
            var command = new RemoveCatalogProviderCommand()
            {
                Id = id
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}