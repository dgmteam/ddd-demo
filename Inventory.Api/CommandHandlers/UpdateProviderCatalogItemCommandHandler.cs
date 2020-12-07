using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Inventory.Infrastructure;
using MediatR;

namespace Inventory.Api.CommandHandlers
{
    public class UpdateProviderCatalogItemCommandHandler : IRequestHandler<UpdateProviderCatalogItemCommand, int>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly UnitOfWork _unitOfWork;

        public UpdateProviderCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository, UnitOfWork unitOfWork)
        {
            _catalogItemRepository = catalogItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateProviderCatalogItemCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Commit();
            return 0;
        }
    }
}