using AppMotorista.ViewModels;

namespace AppMotorista.Pages;

public partial class EmbarquePage : ContentPage
{
    public EmbarquePage()
    {
        InitializeComponent();
        BindingContext = new EmbarqueViewModel();
    }
}