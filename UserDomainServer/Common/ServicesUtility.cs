namespace UserDomainServer.Common
{
    public static class ServicesUtility
    {
        public static T GetAttribute<T>(HttpContext context) where T : class
        {
            Endpoint endpoint = context.GetEndpoint();
            return endpoint?.Metadata?.GetMetadata<T>();
        }

        public static bool IsDevelopmentEnvironment()
        {
            // output additional information in the errors when in development mode
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            bool isDevelopment = environment == Environments.Development;
            return isDevelopment;
        }

    }
}
