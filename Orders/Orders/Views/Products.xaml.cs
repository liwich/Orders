using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.ViewModels;
using Xamarin.Forms;

namespace Orders.Views
{
    public partial class Products : ContentPage
    {
        private ProductsViewModel vm;

        public Products()
        {
            InitializeComponent();

            vm = new ProductsViewModel();
            vm.LoadProductsCommand.Execute(this);

            BindingContext = vm;
        }

        private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var x = sender as ListView;
            x.SelectedItem = null;
        }
    }
}
