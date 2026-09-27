using CSharpFunctionalExtensions;
using Crud.AssetManagement.Commands.Utils;
using Crud.AssetManagement.DTOs.Asset.Enum;

namespace Crud.AssetManagement.Commands.Asset.Decorators
{
    // Wolverine middleware that runs before AddAssetCommandHandler (replaces the MediatR
    // IPipelineBehavior). Applied to AddAssetCommand only, in CommandsWolverineExtensions.
    //
    // Wolverine middleware cannot short-circuit with a response value: returning
    // HandlerContinuation.Stop makes InvokeAsync<Result<string>> return default(Result<string>),
    // which reads as a success. So the validation Result is returned instead, and Wolverine
    // passes it into AddAssetCommandHandler.Handle, which returns the failure.
    public static class ValidateAssetObjectDecorator
    {
        public static Result Before(AddAssetCommand request)
        {
            if (request.AssetTypeId == (int)AssetType.Other && request.AssetMeter != null)
            {
                return Result.Failure(CommandMessageResource.INVALID_ASSETMETER_DETAILS);
            }
            else if ((request.AssetTypeId == (int)AssetType.Copier || request.AssetTypeId == (int)AssetType.Printer) && request.AssetMeter == null)
            {
                return Result.Failure(string.Format(CommandMessageResource.NOT_EXISTS, CommandMessageResource.ASSET_METER));
            }

            return Result.Success();
        }
    }
}
