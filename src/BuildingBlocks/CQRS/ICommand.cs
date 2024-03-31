
using MediatR;
namespace BuildingBlocks.CQRS;
public interface ICommand<in TRequest, out TResponse> : IRequest<TResponse>
{
}
