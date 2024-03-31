using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.StoreBasket;

public record StoreBusketRequest(string UserName, List<ShoppingCartItem> Items);
public record StoreBusketResponse(ShoppingCart Cart);

public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBusketRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreBusketCommnad>();
            var result = await sender.Send(command);
            var response = result.Adapt<StoreBusketResponse>();
            return Results.Ok(response);
        }).WithDisplayName("Store Busket");
    }
}

public record StoreBusketResult(ShoppingCart Cart);
public record StoreBusketCommnad(string UserName, List<ShoppingCartItem> Items) : IRequest<StoreBusketResult>;

public class StorBasketHandler : IRequestHandler<StoreBusketCommnad, StoreBusketResult>
{
    public async Task<StoreBusketResult> Handle(StoreBusketCommnad command, CancellationToken cancellationToken)
    {
        return new StoreBusketResult(new ShoppingCart(command.UserName));
    }
}



