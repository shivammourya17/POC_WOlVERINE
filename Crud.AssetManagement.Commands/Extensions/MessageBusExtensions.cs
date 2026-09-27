using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Wolverine;
using Crud.AssetManagement.Commands.Shared;

namespace Crud.AssetManagement.Commands.Extensions
{
    public static class MessageBusExtensions
    {
        public static async Task<Result<TResponse>> CommandDispatchAsync<TCommand, TResponse>(
            this IMessageBus bus, IMapper mapper, object source)
            where TCommand : ICommand<Result<TResponse>>
        {
            var command = mapper.Map<TCommand>(source);

            return await bus.InvokeAsync<Result<TResponse>>(command);
        }
    }
}
