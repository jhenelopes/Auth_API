namespace auth_api.Token
{
    public static class Configuration
    {
        private static string? _privateKey;

        public static void Initialize(IConfiguration configuration)
        {
            _privateKey = configuration["JwtSettings:PrivateKey"];

            if (string.IsNullOrEmpty(_privateKey))
                throw new Exception("PrivateKey is missing from configuration.");
        }

        public static string PrivateKey =>
            _privateKey ?? throw new InvalidOperationException("Configuration not initialized.");
    }
}
