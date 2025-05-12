namespace Utilities.Utilities
{
    public static class ConstantsConfig
    {
        public static readonly string DefaultUriWebApi = "api/v1/";

        public static readonly string DocumentApiEndPoint = "DOCUMENTATION_ENDPOINT_SWAGGER_JSON";
        public static readonly string DocumentApiTitle = "Api Million Builging";
        public static readonly string DocumentApiVersion = "v1";
        public static readonly string DocumentApiBearer = "Bearer";
        public static readonly string DocumentApiAuthorization = "Authorization";
        public static readonly string DocumentApiBearerFormat = "JWT";
        public static readonly string DocumentApiDescripcion = "Token JWT ";

        public static readonly string ConfigurationApplicationCors = "CONFIGURATION_APPLICATION_CORS_POLICY";
        public static readonly string ConfigurationCorsPolicy = "CORS_POLICY";

        public static readonly string JwtIssuer = "JWT_ISSUER";
        public static readonly string JwtAudience = "JWT_AUDIENCE";
        public static readonly string JwtKey = "JWT_KEY";
        public static readonly string JwtExpire = "JWT_EXPIRE";

        public static readonly string ConectionStringDataBase = "CONNECTION_STRING_DATABASE";
    }

    public static class ConstantsException
    {
        public static readonly string ValueInvalid = "The value: {0} is invalid in method: {1}";
        public static readonly string PropertyInvalid = "The property: {0} does not exist on type: {1}";
        public static readonly string OperationInvalid = "The operator: {0} is not supporte";
        public static readonly string ModelInvalid = "Some fields have validation errors. Please review and try again.";

        public static readonly string OwnerNotFound = "The owner does not exist";
        public static readonly string PropertyNotFound = "The property does not exist";
        public static readonly string PropertyCodeDuplicate = "Property with this code: {0}, already exists";
        public static readonly string PropertyAddressDuplicate = "Property with this address: {0}, already exists";
    }

    public static class ConstantsQuery {
        public static readonly string OrderAscending = "OrderBy";
        public static readonly string OrderDescending = "OrderByDescending";
    }


}
