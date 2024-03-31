using Catalog.API.Models;
using Marten;
using MediatR;
public record GetCatalogResult(IEnumerable<Product> Products);
public record GetCatalogQuery : IRequest<GetCatalogResult>;
public class GetCatalogHandler(IDocumentSession session) : IRequestHandler<GetCatalogQuery, GetCatalogResult>
{
    public async Task<GetCatalogResult> Handle(GetCatalogQuery command, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetCatalogResult(products);

    }
}