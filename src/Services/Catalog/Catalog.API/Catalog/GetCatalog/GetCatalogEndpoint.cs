using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.GetCatalog;
public record GetCatalogResponse(IEnumerable<Product> Products);
public class GetCatalogEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product", async (ISender sender) =>
        {
            var result = await sender.Send(new GetCatalogQuery());

            var response = result.Adapt<GetCatalogResponse>();

            return Results.Ok(response);

        })
    .WithName("Get All Catalog")
    .Produces<GetCatalogResponse>(StatusCodes.Status200OK)
    .WithSummary("Get All Catalog")
    .WithDescription("Get All Catalog");
    }
}