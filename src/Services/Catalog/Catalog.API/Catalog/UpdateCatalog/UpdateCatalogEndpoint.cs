using Carter;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.UpdateCatalog
{
    public record UpdateCatalogRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Quantity);
    public record UpdateCatalogResponse(Guid Id);
    public class UpdateCatalogEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/product/{id}", async (UpdateCatalogRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateCatalogCommand>();
                var result = await sender.Send(command);
                var resupone = result.Adapt<UpdateCatalogResponse>();
                return Results.Ok(resupone);

            })
        .WithName("UpdateProduct")
        .Produces<UpdateCatalogResponse>(StatusCodes.Status200OK)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
        }
    }
}
