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
    public partial class MenuPrincipal : ContentPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            //Verificar el estado activo en BD y mostrar en label:  lblestado.Text = "Estado de venta: Activo";

            if (e.Value)
            {
                await Navigation.PushAsync(new Views.Mapa());
            }
            else
            {
                await DisplayAlert("Estado actualizado", "Se ha actualizado su estado a inactivo", "OK");
            }
        }

        private async void btnPedidos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Pedidos());
        }

        private async void btnProductos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Productos());
        }

        private async void btnConfig_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Configuracion());
        }
    }
}