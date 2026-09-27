namespace Crud.AssetManagement.Queries.Shared
{
    // Marker replacing MediatR's IRequest<T>. Lets QueryDispatchAsync infer the result type.
    public interface IQuery<TResult>
    {
    }
}
