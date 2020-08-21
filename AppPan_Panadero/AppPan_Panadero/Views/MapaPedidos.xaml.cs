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
    public partial class MapaPedidos : ContentPage
    {
        public MapaPedidos(Position clientLocation)
        {
            InitializeComponent();
            DisplayClientLoc(clientLocation);
        }

        public void DisplayClientLoc(Position clientPosition)
        {
            try
            {

                if (clientPosition != null)
                {

                    Pin clientPin = new Pin
                    {
                        Label = "Cliente",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("PickUpPin.png"),
                        Position = clientPosition,
                    };

                    map.Pins.Add(clientPin);

                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(clientPosition, Distance.FromKilometers(.444));
                    map.MoveToRegion(mapSpan);

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }


        async void btnRechazar_Clicked(object sender, EventArgs e)
        {
            //Modificar pedido en BD
            await DisplayAlert("Pedido rechazado :(", "El cliente ha sido notificado.", "OK");
            await Navigation.PopAsync();
        }

        private async void btnAceptar_Clicked(object sender, EventArgs e)
        {
            //Modificar pedido en BD
            await DisplayAlert("Pedido aceptado!", "El cliente ha sido notificado y te espera en su domicilio", "Good");
            await Navigation.PopAsync();
        }
    }
}