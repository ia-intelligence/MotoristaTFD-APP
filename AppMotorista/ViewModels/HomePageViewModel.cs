using AppMotorista;
using AppMotorista.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MotoristaApp.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty]
    private bool menuAberto;

    [ObservableProperty]
    private string nomeMotorista = "Gabriel Almeida";

    [ObservableProperty]
    private string emailMotorista = "gabriel.almeida@email.com";

    public ObservableCollection<MenuCardItem> CardsHome { get; } = new();
    public ObservableCollection<SideMenuItem> ItensMenu { get; } = new();

    public HomePageViewModel()
    {
        CardsHome.Add(new MenuCardItem
        {
            Titulo = "Roteiros",
            Descricao = "Visualize sua escala, horários e rota.",
            Icone = "ic_roteiros.png",
            Rota = "RoteirosPage"
        });

        CardsHome.Add(new MenuCardItem
        {
            Titulo = "Lista de Passageiros",
            Descricao = "Veja a lista de pacientes e acompanhantes no veículo.",
            Icone = "ic_passageiros.png",
            Rota = "PassageirosPage"
        });

        CardsHome.Add(new MenuCardItem
        {
            Titulo = "Check-in de Passageiros",
            Descricao = "Faça o check-in dos passageiros para embarque.",
            Icone = "ic_checkin.png",
            Rota = "CheckinPage"
        });

        CardsHome.Add(new MenuCardItem
        {
            Titulo = "Navegar (GPS)",
            Descricao = "Inicie a navegação GPS para o próximo local.",
            Icone = "ic_gps.png",
            Rota = "NavegacaoPage"
        });

        CardsHome.Add(new MenuCardItem
        {
            Titulo = "Alertas e Ocorrências",
            Descricao = "Visualize alertas e registre ocorrências.",
            Icone = "ic_alerta.png",
            Rota = "AlertasPage"
        });

        ItensMenu.Add(new SideMenuItem { Titulo = "Início", Icone = "ic_home.png", Rota = "HomePage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Roteiros", Icone = "ic_roteiros.png", Rota = "RoteirosPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Lista de Passageiros", Icone = "ic_passageiros.png", Rota = "PassageirosPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Check-in de Passageiros", Icone = "ic_checkin.png", Rota = "CheckinPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Navegar (GPS)", Icone = "ic_gps.png", Rota = "NavegacaoPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Alertas e Ocorrências", Icone = "ic_alerta.png", Rota = "AlertasPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Gerenciar Destinos", Icone = "ic_destinos.png", Rota = "DestinosPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Histórico de Viagens", Icone = "ic_historico.png", Rota = "HistoricoPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Configurações", Icone = "ic_config.png", Rota = "ConfigPage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Suporte", Icone = "ic_suporte.png", Rota = "SuportePage" });
        ItensMenu.Add(new SideMenuItem { Titulo = "Sair", Icone = "ic_sair.png", Rota = "Sair" });
    }

    [RelayCommand]
    private void AlternarMenu()
    {
        MenuAberto = !MenuAberto;
    }

    [RelayCommand]
    private void FecharMenu()
    {
        MenuAberto = false;
    }

    [RelayCommand]
    private async Task AbrirCard(MenuCardItem item)
    {
        if (item is null)
            return;

        await App.Current.MainPage.DisplayAlertAsync("Card", $"Abrir: {item.Titulo}", "OK");
    }

    [RelayCommand]
    private async Task AbrirItemMenu(SideMenuItem item)
    {
        if (item is null)
            return;

        MenuAberto = false;
        await App.Current.MainPage.DisplayAlertAsync("Menu", $"Abrir: {item.Titulo}", "OK");
    }

    [RelayCommand]
    private async Task AbrirQrCode()
    {
        await App.Current.MainPage.DisplayAlertAsync("QR Code", "Abrir leitor de QR Code", "OK");
    }

    [RelayCommand]
    private async Task IrInicio()
    {
        await App.Current.MainPage.DisplayAlertAsync("Bottom Bar", "Início", "OK");
    }

    [RelayCommand]
    private async Task IrNavegar()
    {
        await App.Current.MainPage.DisplayAlertAsync("Bottom Bar", "Navegar", "OK");
    }

    [RelayCommand]
    private async Task IrAlertas()
    {
        await App.Current.MainPage.DisplayAlertAsync("Bottom Bar", "Alertas", "OK");
    }

    [RelayCommand]
    private async Task IrConfig()
    {
        await App.Current.MainPage.DisplayAlertAsync("Bottom Bar", "Configurações", "OK");
    }
}