using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Managers;
using Orders.Models;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace Orders.ViewModels
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private ProductsManager productsManager;
        public ICollection<Product> Products { get; set; }
        public IEnumerable<Product> ProductsFiltered { get; set; }
        public Command LoadProductsCommand { get; set; }

        private bool busy;

        public bool Busy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
            }
        }


        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>();
            productsManager = new ProductsManager();
            LoadProductsCommand = new Command(
                async () =>
                    await LoadProducts()
                );
        }

        private async Task LoadProducts()
        {
            Busy = true;
            try
            {
                var products = await productsManager.GetProducts();
                Products.Clear();

                foreach (var product in products)
                {
                    Products.Add(product);
                }
                Busy = false;
            }
            catch (Exception ex)
            {
                Busy = false;
                Debug.WriteLine("Error loading products " + ex.Message);
            }
        }

        public void FilterProducts(string text)
        {
            var products = Products.Where(x => x.Name.Contains(text));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
