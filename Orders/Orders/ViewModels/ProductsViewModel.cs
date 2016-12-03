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

        private string filter;

        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                OnPropertyChanged();
                FilterProducts();
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
                ProductsFiltered = await productsManager.GetProducts();
                Products.Clear();

                foreach (var product in ProductsFiltered)
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


        public void FilterProducts()
        {
            if (!string.IsNullOrWhiteSpace(Filter))
            {
                var products = ProductsFiltered.Where(
                    x =>
                        x.Name.ToLower().Contains(Filter.ToLower()) ||
                        x.Description.ToLower().Contains(Filter.ToLower())
                        );
                Products.Clear();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
                Busy = false;
            }
            else
            {
                Products.Clear();

                foreach (var product in ProductsFiltered)
                {
                    Products.Add(product);
                }
                Busy = false;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
