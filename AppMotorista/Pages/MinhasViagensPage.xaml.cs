using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class MinhasViagensPage : ContentPage
{
    public MinhasViagensPage()
    {
        InitializeComponent();
        BindingContext = new MinhasViagensViewModel();
    }
}