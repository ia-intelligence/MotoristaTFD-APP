using MotoristaApp.ViewModels;

namespace MotoristaApp.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new HomePageViewModel();
    }
}