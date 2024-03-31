using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.DeleteBasket;
public record DeleteBasketResponse(bool success);
public record DeleteBasketRequest(string userName);
public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var request = userName.Adapt<DeleteBasketRequest>();
            var command = request.Adapt<DeleteBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteBasketResponse>();
            return Results.Ok(response);
        }).WithName("DeleteBasketByUsername")
        .Produces<DeleteBasketRequest>(StatusCodes.Status201Created)
        .WithSummary("Delete Basket By Username")
        .WithDescription("Delete Basket By Username");
    }
}


public record DeleteBasketCommand(string userName) : IRequest<DeleteBasketResult>;
public record DeleteBasketResult(bool Success);
public class GetBasketQueryHandler : IRequestHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        return new DeleteBasketResult(true);
    }
}