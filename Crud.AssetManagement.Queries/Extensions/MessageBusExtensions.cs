using System.Threading.Tasks;
using Wolverine;
using Crud.AssetManagement.Queries.Shared;

namespace Crud.AssetManagement.Queries.Extensions
{
    public static class MessageBusExtensions
    {
        public static Task<TResult> QueryDispatchAsync<TResult>(this IMessageBus bus, IQuery<TResult> query)
        {
            return bus.InvokeAsync<TResult>(query);
        }
    }
}
