namespace Crud.AssetManagement.Commands.Shared
{
    // Marker replacing MediatR's IRequest<T>. Wolverine does not need it (handlers are
    // discovered by convention), but it keeps CommandDispatchAsync strongly typed.
    public interface ICommand<TResponse>
    {
    }
}
