using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppMotorista.Pages;

public partial class MapaViagemPage : ContentPage
{
    public MapaViagemPage()
    {
        InitializeComponent();

        var local = new Location(-19.9245, -43.9352);

        MapaView.MoveToRegion(
            MapSpan.FromCenterAndRadius(local, Distance.FromKilometers(2)));

        MapaView.Pins.Add(new Pin
        {
            Label = "Destino da viagem",
            Address = "Teste inicial do mapa",
            Location = local
        });
    }
}