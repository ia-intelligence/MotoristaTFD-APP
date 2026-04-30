using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty]
    private bool menuAberto;

    [ObservableProperty]
    private string nomeMotorista = "João Silva";

    [ObservableProperty]
    private string idMotorista = "ID 482910";

    [ObservableProperty]
    private string emailMotorista = "joao.silva@email.com";

    [ObservableProperty]
    private string resumoAlertas =
        "Interdição na via principal para o Hospital das Clínicas. Use a rota alternativa via Av. Industrial.";

    [ObservableProperty]
    private TripSummaryItem? proximaViagem;

    public string SaudacaoMotorista => $"Olá, {NomeMotorista}";

    public int TotalViagens => ViagensDoDia.Count;

    public int TotalPassageiros => 45;

    public int TotalAlertas => 1;

    public ObservableCollection<TripSummaryItem> ViagensDoDia { get; } = new();

    public ObservableCollection<QuickAccessItem> AtalhosPrincipais { get; } = new();

    public ObservableCollection<QuickAccessItem> AtalhosConsulta { get; } = new();

    public ObservableCollection<SideMenuItem> ItensMenu { get; } = new();

    public HomePageViewModel()
    {
        PopularViagens();
        PopularAtalhosPrincipais();
        PopularMenu();
    }

    private void PopularViagens()
    {
        ViagensDoDia.Clear();

        ViagensDoDia.Add(new TripSummaryItem
        {
            Titulo = "Próxima Viagem",
            Data = "Hoje",
            Horario = "08:30",
            Destino = "Hospital das Clínicas",
            Veiculo = "Van 05",
            Status = "CONFIRMADA",
            ResumoPassageiros = "15 passageiros",
            EquipeApoio = "Equipe de apoio disponível",
            ResumoRota = "Rota principal",
            VeiculoProprio = false
        });

        ViagensDoDia.Add(new TripSummaryItem
        {
            Titulo = "Viagem Seguinte",
            Data = "Hoje",
            Horario = "09:20",
            Destino = "Centro de Especialidades",
            Veiculo = "Van 02",
            Status = "PENDENTE",
            ResumoPassageiros = "12 passageiros",
            EquipeApoio = "Sem equipe de apoio",
            ResumoRota = "Rota secundária",
            VeiculoProprio = false
        });

        ViagensDoDia.Add(new TripSummaryItem
        {
            Titulo = "Terceira Viagem",
            Data = "Hoje",
            Horario = "10:15",
            Destino = "Policlínica Municipal",
            Veiculo = "Van 01",
            Status = "CONFIRMADA",
            ResumoPassageiros = "18 passageiros",
            EquipeApoio = "Equipe de apoio disponível",
            ResumoRota = "Rota oeste",
            VeiculoProprio = false
        });

        ProximaViagem = ViagensDoDia.FirstOrDefault();

        OnPropertyChanged(nameof(TotalViagens));
        OnPropertyChanged(nameof(TotalPassageiros));
        OnPropertyChanged(nameof(TotalAlertas));
    }

    private void PopularAtalhosPrincipais()
    {
        AtalhosPrincipais.Clear();

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Minhas Viagens",
            Descricao = "Veja as viagens do dia.",
            Icone = "clipboard_check_icon.svg",
            Rota = nameof(MinhasViagensPage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Planejamento",
            Descricao = "Consulte o planejamento de rotas.",
            Icone = "calendar_icon.svg",
            Rota = nameof(PlanejamentoRotasPage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Mapa",
            Descricao = "Acesse o mapa da viagem.",
            Icone = "trip_icon.svg",
            Rota = nameof(MapaViagemPage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Embarque",
            Descricao = "Confirme passageiros.",
            Icone = "qrcode_icon.svg",
            Rota = nameof(EmbarquePage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Ocorrências",
            Descricao = "Registre problemas da viagem.",
            Icone = "bell_pin_icon.svg",
            Rota = nameof(AlertasPage)
        });

        AtalhosPrincipais.Add(new QuickAccessItem
        {
            Titulo = "Suporte",
            Descricao = "Acesse ajuda rápida.",
            Icone = "support_icon.svg",
            Rota = nameof(SuportePage)
        });
    }

    private void PopularMenu()
    {
        ItensMenu.Clear();

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Início",
            Icone = "home_icon.svg",
            Rota = nameof(HomePage),
            Ativo = true
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Minhas Viagens",
            Icone = "clipboard_check_icon.svg",
            Rota = nameof(MinhasViagensPage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Planejamento de Rotas",
            Icone = "trip_icon.svg",
            Rota = nameof(PlanejamentoRotasPage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Localizações",
            Icone = "location_icon.svg",
            Rota = nameof(LocaisPage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Suporte",
            Icone = "support_icon.svg",
            Rota = nameof(SuportePage)
        });
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

        await NavegarOuMostrarPlaceholder(item.Rota, item.Titulo);
    }

    [RelayCommand]
    private async Task VerDetalheViagem(TripSummaryItem item)
    {
        if (item is null)
            return;

        await Shell.Current.GoToAsync(nameof(DetalheViagemPage));
    }

    [RelayCommand]
    private async Task AbrirQrCode()
    {
        await NavegarOuMostrarPlaceholder(nameof(QrCodeScannerPage), "Escanear embarque");
    }

    [RelayCommand]
    private Task IrInicio()
    {
        MenuAberto = false;
        return Task.CompletedTask;
    }

    [RelayCommand]
    private async Task IrViagens()
    {
        await Shell.Current.GoToAsync(nameof(MinhasViagensPage));
    }

    [RelayCommand]
    private async Task IrMapa()
    {
        await NavegarOuMostrarPlaceholder(nameof(MapaViagemPage), "Mapa");
    }

    [RelayCommand]
    private async Task IrAlertas()
    {
        await NavegarOuMostrarPlaceholder(nameof(AlertasPage), "Alertas e Ocorrências");
    }

    [RelayCommand]
    private async Task IrPerfil()
    {
        await NavegarOuMostrarPlaceholder(nameof(ConfigPage), "Perfil");
    }

    [RelayCommand]
    private async Task Sair()
    {
        MenuAberto = false;

        await Shell.Current.GoToAsync("//LoginPage");
    }

    private static readonly HashSet<string> RotasImplementadas = new()
    {
        nameof(HomePage),
        nameof(MinhasViagensPage),
        nameof(DetalheViagemPage),
        nameof(PlanejamentoRotasPage),
        nameof(MapaViagemPage),
        nameof(LocaisPage),
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
            "Essa tela será criada na próxima etapa.",
            "OK");
    }
}