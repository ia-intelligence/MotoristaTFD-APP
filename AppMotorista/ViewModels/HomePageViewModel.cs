using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private bool menuAberto;
    [ObservableProperty] private string nomeMotorista = "Gabriel Almeida";
    [ObservableProperty] private string emailMotorista = "gabriel.almeida@email.com";
    [ObservableProperty] private string resumoDia = "3 viagens programadas • 1 alerta pendente";
    [ObservableProperty] private string resumoAlertas = "1 atraso operacional • 1 embarque pendente";
    [ObservableProperty] private TripSummaryItem? proximaViagem;

    public ObservableCollection<TripSummaryItem> ViagensDoDia { get; } = new();
    public ObservableCollection<QuickAccessItem> AtalhosPrincipais { get; } = new();
    public ObservableCollection<QuickAccessItem> AtalhosConsulta { get; } = new();
    public ObservableCollection<SideMenuItem> ItensMenu { get; } = new();

    public HomePageViewModel()
    {
        PopularViagens();
        PopularAtalhosPrincipais();
        PopularAtalhosConsulta();
        PopularMenu();
    }

    private void PopularViagens()
    {
        ViagensDoDia.Add(new TripSummaryItem
        {
            Titulo = "Próxima Viagem",
            Data = "24/04/2024",
            Horario = "07:40",
            Destino = "Hospital Ana Nery",
            Veiculo = "Citroën Jumpy - Placa QWE-1234",
            Status = "Confirmada"
        });

        ViagensDoDia.Add(new TripSummaryItem
        {
            Titulo = "Viagem Seguinte",
            Data = "24/04/2024",
            Horario = "08:20",
            Destino = "Policlínica Regional Oeste",
            Veiculo = "Renault Master - Placa RTY-9087",
            Status = "Pendente"
        });

        ViagensDoDia.Add(new TripSummaryItem
        {
            Titulo = "Terceira Viagem",
            Data = "24/04/2024",
            Horario = "09:10",
            Destino = "Unidade Básica São José",
            Veiculo = "Ford Transit - Placa HJK-4521",
            Status = "Recebida"
        });

        ProximaViagem = ViagensDoDia.FirstOrDefault();
    }
    //Botões dos atalhos principais
    private void PopularAtalhosPrincipais()
    {
        AtalhosPrincipais.Clear();

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Minhas Viagens",
            Descricao = "Veja as viagens programadas e confirmadas do dia.",
            Icone = "clipboard_check_icon.svg",
            Rota = nameof(MinhasViagensPage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Mapa da viagem",
            Descricao = "Acesse a rota e os pontos do deslocamento atual.",
            Icone = "trip_icon.svg",
            Rota = nameof(MapaViagemPage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Embarque",
            Descricao = "Confirme passageiros e valide presença na saída.",
            Icone = "qrcode_icon.svg",
            Rota = nameof(EmbarquePage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Alertas e Ocorrências",
            Descricao = "Veja alertas e registre problemas da viagem.",
            Icone = "bell_pin_icon.svg",
            Rota = nameof(AlertasPage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Suporte",
            Descricao = "Acesse ajuda rápida e canais de atendimento.",
            Icone = "support_icon.svg",
            Rota = nameof(SuportePage)
        });
    }

    private void PopularAtalhosConsulta()
    {
        AtalhosConsulta.Add(new QuickAccessItem
        {
            Titulo = "Veículo da viagem",
            Descricao = "Consulte placa, modelo, capacidade e situação operacional.",
            Icone = "fleet_icon.svg",
            Rota = nameof(CadastroVeiculosPage)
        });

        AtalhosConsulta.Add(new QuickAccessItem
        {
            Titulo = "Pontos da viagem",
            Descricao = "Veja locais de embarque, destino e sequência da rota.",
            Icone = "location_icon.svg",
            Rota = nameof(LocaisPage)
        });

        AtalhosConsulta.Add(new QuickAccessItem
        {
            Titulo = "Passageiros",
            Descricao = "Consulte pacientes e acompanhantes vinculados à viagem.",
            Icone = "tasklist_icon.svg",
            Rota = nameof(AgrupamentoPacientesPage)
        });

        AtalhosConsulta.Add(new QuickAccessItem
        {
            Titulo = "Equipe de apoio",
            Descricao = "Veja os profissionais de apoio vinculados à viagem.",
            Icone = "medical_staff_icon.svg",
            Rota = nameof(EquipeApoioPage)
        });
    }

    private void PopularMenu()
    {
        ItensMenu.Clear();

        ItensMenu.Add(new SideMenuItem { Titulo = "Início", Icone = "menuhamburguer_icon.svg", Rota = nameof(HomePage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Minhas Viagens", Icone = "clipboard_check_icon.svg", Rota = nameof(MinhasViagensPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Mapa", Icone = "trip_icon.svg", Rota = nameof(MapaViagemPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Embarque", Icone = "qrcode_icon.svg", Rota = nameof(EmbarquePage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Alertas e Ocorrências", Icone = "bell_pin_icon.svg", Rota = nameof(AlertasPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Suporte", Icone = "support_icon.svg", Rota = nameof(SuportePage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Configurações", Icone = "config_icon.svg", Rota = nameof(ConfigPage) });
        ItensMenu.Add(new SideMenuItem { Titulo = "Sair", Icone = "power_icon.svg", Rota = "Sair" });
    }

    [RelayCommand]
    private void AlternarMenu() => MenuAberto = !MenuAberto;

    [RelayCommand]
    private void FecharMenu() => MenuAberto = false;

    [RelayCommand]
    private async Task AbrirAtalho(QuickAccessItem item)
    {
        if (item is null || string.IsNullOrWhiteSpace(item.Rota))
            return;

        await NavegarOuMostrarPlaceholder(item.Rota, item.Titulo);
    }

    [RelayCommand]
    private async Task AbrirItemMenu(SideMenuItem item)
    {
        if (item is null || string.IsNullOrWhiteSpace(item.Rota))
            return;

        MenuAberto = false;

        if (item.Rota == nameof(HomePage))
            return;

        if (item.Rota == "Sair")
        {
            await Shell.Current.DisplayAlertAsync("Sessão", "Ação de sair ainda será implementada.", "OK");
            return;
        }

        await NavegarOuMostrarPlaceholder(item.Rota, item.Titulo);
    }

    [RelayCommand]
    private async Task VerDetalheViagem(TripSummaryItem item)
    {
        if (item is null) return;

        await Shell.Current.GoToAsync(nameof(DetalheViagemPage));
    }

    [RelayCommand]
    private async Task AbrirQrCode()
    {
        await NavegarOuMostrarPlaceholder(nameof(QrCodeScannerPage), "Escanear embarque");
    }

    [RelayCommand]
    private async Task IrInicio() => await Shell.Current.GoToAsync(nameof(HomePage));

    [RelayCommand]
    private async Task IrViagens() => await Shell.Current.GoToAsync(nameof(MinhasViagensPage));

    [RelayCommand]
    private async Task IrMapa() => await NavegarOuMostrarPlaceholder(nameof(MapaViagemPage), "Mapa");

    [RelayCommand]
    private async Task IrAlertas() => await NavegarOuMostrarPlaceholder(nameof(AlertasPage), "Alertas e Ocorrências");

    [RelayCommand]
    private async Task IrConfig() => await NavegarOuMostrarPlaceholder(nameof(ConfigPage), "Configurações");

    private static readonly HashSet<string> RotasImplementadas = new()
    {
        nameof(HomePage),
        nameof(MinhasViagensPage),
        nameof(DetalheViagemPage),
        nameof(MapaViagemPage),
        nameof(EmbarquePage),
        nameof(AlertasPage),
        nameof(OcorrenciaFormPage),
        nameof(ConfigPage),
        nameof(SuportePage),
        nameof(QrCodeScannerPage)
    };

    private static async Task NavegarOuMostrarPlaceholder(string rota, string titulo)
    {
        if (RotasImplementadas.Contains(rota))
        {
            await Shell.Current.GoToAsync(rota);
            return;
        }

        await Shell.Current.DisplayAlertAsync(
            titulo,
            "Essa tela mockada será criada na próxima etapa.",
            "OK");
    }
}