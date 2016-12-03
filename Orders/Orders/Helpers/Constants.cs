using Microsoft.WindowsAzure.MobileServices;

namespace Orders.Helpers
{
    public class Constants
    {
        private static string ApplicationURL = @"https://ordersliwich.azurewebsites.net";

        public static IMobileServiceClient Client;

        public static void InitializeServiceClient()
        {
            Client = new MobileServiceClient(ApplicationURL);
        }
    }
}
