namespace Crud.AssetManagement.Commands.Utils
{
    // Centralised, friendly command validation/error messages.
    // Mirrors the pattern used by the org's CommandMessageResource.
    public static class CommandMessageResource
    {
        public const string NOT_EXISTS = "{0} does not exist.";
        public const string ALREADY_EXISTS = "{0} already exists.";
        public const string ASSET_METER = "Asset meter";
        public const string INVALID_ASSETMETER_DETAILS = "Asset meter details are not valid for this asset type.";
        public const string NAME_REQUIRED = "Name is required.";
    }
}
