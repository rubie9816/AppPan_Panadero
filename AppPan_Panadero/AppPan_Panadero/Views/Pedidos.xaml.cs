using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace AppPan_Panadero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedidos : ContentPage
    {
        public Pedidos()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<Models.Usuario> clientes = new List<Models.Usuario>();
            clientes.Add(new Models.Usuario
            {
                ubicacion = new Position(latitude: 32.632017, longitude: -115.389143)
            });
            clientes.Add(new Models.Usuario
            {
                ubicacion = new Position(latitude: 32.632948, longitude: -115.388649)
            });
            clientes.Add(new Models.Usuario
            {
                ubicacion = new Position(latitude: 32.632844, longitude: -115.387165)
            });

            listView.ItemsSource = clientes;

        }
        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Models.Usuario)e.SelectedItem;

            await Navigation.PushAsync(new Views.MapaPedidos(obj.ubicacion));
        }
    }
}