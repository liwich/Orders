
namespace Orders.Views
{
    using Xamarin.Forms;

    public partial class Product : ContentPage
    {
        private Orders.Models.Product product;

        public Product(Orders.Models.Product product)
        {
            this.product = product;
            InitializeComponent();
            BindingContext = this.product;
        }
    }
}
