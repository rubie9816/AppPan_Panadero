using Plugin.Geolocator;
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
    public partial class Mapa : ContentPage
    {
        Pin userPin;
        Circle userRadius;
        int mapZoom;
        int radiusSize;
        public Mapa()
        {
            InitializeComponent();
            mapZoom = 500;

            userPin = new Pin();
            userPin.Label = "Me";
            userPin.Type = PinType.Place;
            userPin.Icon = BitmapDescriptorFactory.FromBundle("PickUpPin.png");
            userPin.IsDraggable = true;

            userRadius = new Circle();
            userRadius.StrokeWidth = 4;
            userRadius.FillColor = Color.FromRgba(1, 55, 1, 0.87);
            userRadius.StrokeColor = Color.Red;
            userRadius.Tag = "Radio de venta";

            DisplayCurLoc();
        }


        public async void DisplayCurLoc()
        {
            try
            {
                // var location = await Geolocation.GetLastKnownLocationAsync();
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);


                if (location != null)
                {
                    Position p = new Position(location.Latitude, location.Longitude);

                    GenerateCircle(p, 100);
                    GeneretePin(p);

                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromMeters(mapZoom));
                    map.MoveToRegion(mapSpan);

                    // Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
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



        private async void Setlocation_ClickedAsync(object sender, EventArgs e)
        {
            //Guardar radio en BD
            await DisplayAlert("Ubicación guardada", "Tu área de entregas ha sido actualizada", "OK");
            await Navigation.PopAsync();
        }

        async void Miubi_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            var location = await locator.GetPositionAsync();
            var position = new Position(location.Latitude, location.Longitude);
            GeneretePin(position);
            GenerateCircle(position, 100);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMeters(500)));
        }

        private void map_PinDragEnd(object sender, PinDragEventArgs e)
        {
            var positions = new Position(e.Pin.Position.Latitude, e.Pin.Position.Longitude);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positions, Distance.FromMeters(500)));
            GenerateCircle(positions, 100);
        }

        private void map_PinDragStart(object sender, PinDragEventArgs e)
        {

        }

        void GenerateCircle(Position position, int radio)
        {
            map.Circles.Remove(userRadius);
            radiusSize = radio;
            userRadius.Center = position;
            userRadius.Radius = new Distance(radio);

            map.Circles.Add(userRadius);
        }
        void GeneretePin(Position position)
        {
            map.Pins.Remove(userPin);
            userPin.Position = position;

            map.Pins.Add(userPin);
        }

        private void AmpliarRadio_Clicked(object sender, EventArgs e)
        {
            GenerateCircle(userRadius.Center, radiusSize + 100);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(userPin.Position, Distance.FromMeters(mapZoom += 100)));
        }

        private void DisminuirRadio_Clicked(object sender, EventArgs e)
        {
            if (radiusSize != 100)
            {
                GenerateCircle(userRadius.Center, radiusSize - 100);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(userPin.Position, Distance.FromMeters(mapZoom -= 100)));
            }
        }
    }
}
