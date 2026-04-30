using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class DetalheViagemViewModel : ObservableObject
{
    [ObservableProperty]
    private bool menuAberto;

    [ObservableProperty]
    private string tituloPagina = "Detalhe da Viagem";

    [ObservableProperty]
    private string status = "INICIADO";

    [ObservableProperty]
    private string data = "15/10";

    [ObservableProperty]
    private string horario = "08:00";

    [ObservableProperty]
    private string destino = "Hospital das Clínicas - Salvador";

    [ObservableProperty]
    private string localResumo = "Salvador, BA";

    [ObservableProperty]
    private string origem = "Ponto Central";

    [ObservableProperty]
    private string paradaIntermediaria = "Av. Luís Viana";

    [ObservableProperty]
    private string destinoCurto = "Hosp. Clínicas";

    [ObservableProperty]
    private string modeloVeiculo = "Sprinter 415";

    [ObservableProperty]
    private int ocupacaoAtual = 17;

    [ObservableProperty]
    private int ocupacaoMaxima = 18;

    [ObservableProperty]
    private string contatoApoio = "Enf. Maria Santos";

    [ObservableProperty]
    private string nomeMotorista = "João Silva";

    [ObservableProperty]
    private string idMotorista = "ID 482910";

    public ObservableCollection<SideMenuItem> ItensMenu { get; } = new();

    public string OcupacaoTexto => $"{OcupacaoAtual}/{OcupacaoMaxima}";

    public double OcupacaoPercentual
        => OcupacaoMaxima <= 0 ? 0 : (double)OcupacaoAtual / OcupacaoMaxima;

    public DetalheViagemViewModel()
    {
        PopularMenu();
    }

    partial void OnOcupacaoAtualChanged(int value)
    {
        OnPropertyChanged(nameof(OcupacaoTexto));
        OnPropertyChanged(nameof(OcupacaoPercentual));
    }

    partial void OnOcupacaoMaximaChanged(int value)
    {
        OnPropertyChanged(nameof(OcupacaoTexto));
        OnPropertyChanged(nameof(OcupacaoPercentual));
    }

    private void PopularMenu()
    {
        ItensMenu.Clear();

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Início",
            Icone = "home_icon.svg",
            Rota = nameof(HomePage)
        });

        ItensMenu.Add(new SideMenuItem
        {
            Titulo = "Minhas Viagens",
            Icone = "clipboard_check_icon.svg",
            Rota = nameof(MinhasViagensPage),
            Ativo = true
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
    private async Task AbrirQrCode()
    {
        await Shell.Current.GoToAsync(nameof(QrCodeScannerPage));
    }

    [RelayCommand]
    private async Task IniciarViagem()
    {
        await Shell.Current.DisplayAlertAsync(
            "Viagem",
            "Fluxo de iniciar viagem mockado.",
            "OK");
    }

    [RelayCommand]
    private async Task AbrirMapa()
    {
        await Shell.Current.GoToAsync(nameof(MapaViagemPage));
    }

    [RelayCommand]
    private async Task AbrirEmbarque()
    {
        await Shell.Current.GoToAsync(nameof(EmbarquePage));
    }

    [RelayCommand]
    private async Task ConfirmarEmbarque()
    {
        await Shell.Current.DisplayAlertAsync(
            "Embarque",
            "Confirmação de embarque mockada.",
            "OK");
    }

    [RelayCommand]
    private async Task RegistrarOcorrencia()
    {
        await Shell.Current.GoToAsync(nameof(OcorrenciaFormPage));
    }

    [RelayCommand]
    private async Task AbrirItemMenu(SideMenuItem item)
    {
        if (item is null || string.IsNullOrWhiteSpace(item.Rota))
            return;

        MenuAberto = false;

        if (item.Rota == nameof(DetalheViagemPage))
            return;

        await NavegarOuMostrarPlaceholder(item.Rota, item.Titulo);
    }

    [RelayCommand]
    private async Task IrInicio()
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }

    [RelayCommand]
    private async Task IrViagens()
    {
        await Shell.Current.GoToAsync(nameof(MinhasViagensPage));
    }

    [RelayCommand]
    private async Task IrAlertas()
    {
        await NavegarOuMostrarPlaceholder(nameof(AlertasPage), "Alertas");
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