namespace Mini_Theatre.Utils
{
    public static class PaypalSetting
    {
        public static string ClientId { get; private set; }
        public static string Secret { get; private set; }
        public static string Url { get; private set; }

        static PaypalSetting()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ClientId = configuration["Payment:Paypal:ClientId"] ?? "";
            Secret = configuration["Payment:Paypal:Secret"] ?? "";
            Url = configuration["Payment:Paypal:Url"] ?? "";
        }
    }
}
