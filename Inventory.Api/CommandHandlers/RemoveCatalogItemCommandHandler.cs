using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Inventory.Infrastructure;
using MediatR;

namespace Inventory.Api.CommandHandlers
{
    public class RemoveCatalogItemCommandHandler : IRequestHandler<RemoveCatalogItemCommand, int>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly UnitOfWork _unitOfWork;

        public RemoveCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository, UnitOfWork unitOfWork)
        {
            _catalogItemRepository = catalogItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(RemoveCatalogItemCommand request, CancellationToken cancellationToken)
        {
            _catalogItemRepository.Remove(request.Id);
            await _unitOfWork.Commit();
            return request.Id;
        }
    }
}