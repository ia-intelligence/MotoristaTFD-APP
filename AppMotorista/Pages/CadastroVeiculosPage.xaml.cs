using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class CadastroVeiculosPage : ContentPage
{
    public CadastroVeiculosPage()
    {
        InitializeComponent();
        BindingContext = new CadastroVeiculosViewModel();
    }
}