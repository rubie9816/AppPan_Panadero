using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPan_Panadero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Productos : ContentPage
    {
        public Productos()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<Models.Producto> productos = new List<Models.Producto>();
            productos.Add(new Models.Producto
            {
                Nombre_producto = "muffin"
            });
            productos.Add(new Models.Producto
            {
                Nombre_producto = "conchita"
            });
            productos.Add(new Models.Producto
            {
                Nombre_producto = "bolillo"
            });

            listView.ItemsSource = productos;

        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Models.Producto)e.SelectedItem;

            await Navigation.PushAsync(new Views.EditarProducto(obj.Id));
        }
    }
}