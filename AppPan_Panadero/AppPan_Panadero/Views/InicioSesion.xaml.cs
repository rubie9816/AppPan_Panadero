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
    public partial class InicioSesion : ContentPage
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {
            //BD: Validar usuario correcto
            await Navigation.PushAsync(new Views.MenuPrincipal());
        }
    }
}