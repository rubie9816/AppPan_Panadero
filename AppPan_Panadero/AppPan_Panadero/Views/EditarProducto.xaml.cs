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
    public partial class EditarProducto : ContentPage
    {
        public EditarProducto(int id_producto)
        {
            InitializeComponent();
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Cambios guardados", "El producto ha sido actualizado", "OK");
            await Navigation.PopAsync();
        }

        private void swDisponibilidad_Toggled(object sender, ToggledEventArgs e)
        {
            
        }
    }
}