using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class PlanejamentoRotasPage : ContentPage
{
    public PlanejamentoRotasPage()
    {
        InitializeComponent();
        BindingContext = new PlanejamentoRotasViewModel();
    }
}