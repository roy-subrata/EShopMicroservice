using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.StoreBasket;
public record GetBasketRequest(string userName)
{
    public string UserName { get; set; } = userName;
}
public class GetBasketResponse(ShoppingCart cart)
{
    public ShoppingCart cart { get; set; } = cart;
}

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var request = new GetBasketRequest(userName);
            var result = await sender.Send(request.Adapt<GetBasketQuery>());
            var response = result.Adapt<GetBasketResponse>();
            return Results.Ok(response);
        }).WithName("GetBasketByUsername")
        .Produces<GetBasketResponse>(StatusCodes.Status201Created)
        .WithSummary("Get Basket By Username")
        .WithDescription("Get Basket By Username");
    }
}


public record GetBasketQuery(string userName) : IRequest<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);
public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        return new GetBasketResult(new ShoppingCart("roy"));
    }
}