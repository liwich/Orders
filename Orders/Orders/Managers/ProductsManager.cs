using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Orders.Models;
using System.Threading.Tasks;

namespace Orders.Managers
{
    public class ProductsManager
    {
        private IMobileServiceTable<Product> table; 

        public ProductsManager()
        {
            var client=Helpers.Constants.Client;
            table = client.GetTable<Product>();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {   
            return table.ToEnumerableAsync();
        }
    }
}
