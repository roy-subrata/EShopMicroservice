using MediatR;

namespace Catalog.API.Catalog.UpdateCatalog
{
    public record UpdateCatalogCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Quantity) :
        IRequest<UpdateCatalogResult>;
    public record UpdateCatalogResult(Guid Id);
    public class UpdateCatalogHandler : IRequestHandler<UpdateCatalogCommand, UpdateCatalogResult>
    {
        public async Task<UpdateCatalogResult> Handle(UpdateCatalogCommand command, CancellationToken cancellationToken)
        {
            return new UpdateCatalogResult(command.Id);
        }
    }
}
