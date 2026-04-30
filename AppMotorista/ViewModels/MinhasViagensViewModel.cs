using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class MinhasViagensViewModel : ObservableObject
{
    [ObservableProperty]
    private bool menuAberto;

    [ObservableProperty]
    private string tituloPagina = "Minhas Viagens";

    [ObservableProperty]
    private string resumoPagina = "3 viagens no dia • 1 em andamento";

    [ObservableProperty]
    private string abaSelecionada = "Confirmadas";

    [ObservableProperty]
    private string nomeMotorista = "João Silva";

    [ObservableProperty]
    private string idMotorista = "ID 482910";

    [ObservableProperty]
    private string emailMotorista = "joao.silva@email.com";

    public ObservableCollection<ReceptionTripItem> Confirmadas { get; } = new();
    public ObservableCollection<ReceptionTripItem> EmAndamento { get; } = new();
    public ObservableCollection<ReceptionTripItem> Finalizadas { get; } = new();

    public ObservableCollection<ReceptionTripItem> ViagensFiltradas { get; } = new();

    public ObservableCollection<SideMenuItem> ItensMenu { get; } = new();

    public string CorFundoConfirmadas => AbaSelecionada == "Confirmadas" ? "#EEF3FF" : "White";
    public string CorTextoConfirmadas => AbaSelecionada == "Confirmadas" ? "#2357C6" : "#6B7280";

    public string CorFundoEmAndamento => AbaSelecionada == "EmAndamento" ? "#EEF3FF" : "White";
    public string CorTextoEmAndamento => AbaSelecionada == "EmAndamento" ? "#2357C6" : "#6B7280";

    public string CorFundoFinalizadas => AbaSelecionada == "Finalizadas" ? "#EEF3FF" : "White";
    public string CorTextoFinalizadas => AbaSelecionada == "Finalizadas" ? "#2357C6" : "#6B7280";

    public MinhasViagensViewModel()
    {
        PopularViagens();
        PopularMenu();
        AtualizarLista();
    }

    private void PopularViagens()
    {
        Confirmadas.Clear();
        EmAndamento.Clear();
        Finalizadas.Clear();

        Confirmadas.Add(new ReceptionTripItem
        {
            Data = "15/10",
            Horario = "07:00",
            Destino = "Hosp. Regional de Urgência",
            Veiculo = "Micro-ônibus",
            Motorista = "Joaquim Mendes",
            Status = "CONFIRMADA",
            TravaFaturamentoAtiva = true,
            ResumoRota = "Terminal Integrado Central • Av. Getúlio Vargas, 450",
            ResumoPassageiros = "12 passageiros",
            EquipeApoio = "Suporte Logístico Ativo",
            VeiculoDetalhe = "PLQ-4122"
        });

        Confirmadas.Add(new ReceptionTripItem
        {
            Data = "16/10",
            Horario = "08:30",
            Destino = "Centro de Reabilitação Sul",
            Veiculo = "Van adaptada",
            Motorista = "Joaquim Mendes",
            Status = "CONFIRMADA",
            TravaFaturamentoAtiva = false,
            ResumoRota = "Posto Central • Centro de Reabilitação Sul",
            ResumoPassageiros = "8 passageiros",
            EquipeApoio = "Sem suporte ativo",
            VeiculoDetalhe = "TRD-7780"
        });

        EmAndamento.Add(new ReceptionTripItem
        {
            Data = "15/10",
            Horario = "09:20",
            Destino = "Hospital das Clínicas",
            Veiculo = "Van 05",
            Motorista = "Joaquim Mendes",
            Status = "EM ANDAMENTO",
            TravaFaturamentoAtiva = true,
            ResumoRota = "Terminal Integrado Central • Hospital das Clínicas",
            ResumoPassageiros = "15 passageiros",
            EquipeApoio = "Suporte Logístico Ativo",
            VeiculoDetalhe = "VAN-0505"
        });

        Finalizadas.Add(new ReceptionTripItem
        {
            Data = "14/10",
            Horario = "14:00",
            Destino = "Hospital Municipal",
            Veiculo = "Van 03",
            Motorista = "Joaquim Mendes",
            Status = "FINALIZADA",
            TravaFaturamentoAtiva = false,
            ResumoRota = "UBS Central • Hospital Municipal",
            ResumoPassageiros = "6 passageiros",
            EquipeApoio = "Sem suporte ativo",
            VeiculoDetalhe = "VAN-0303"
        });
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

    private void AtualizarLista()
    {
        ViagensFiltradas.Clear();

        IEnumerable<ReceptionTripItem> lista = AbaSelecionada switch
        {
            "EmAndamento" => EmAndamento,
            "Finalizadas" => Finalizadas,
            _ => Confirmadas
        };

        foreach (var item in lista)
            ViagensFiltradas.Add(item);
    }

    partial void OnAbaSelecionadaChanged(string value)
    {
        AtualizarLista();

        OnPropertyChanged(nameof(CorFundoConfirmadas));
        OnPropertyChanged(nameof(CorTextoConfirmadas));

        OnPropertyChanged(nameof(CorFundoEmAndamento));
        OnPropertyChanged(nameof(CorTextoEmAndamento));

        OnPropertyChanged(nameof(CorFundoFinalizadas));
        OnPropertyChanged(nameof(CorTextoFinalizadas));
    }

    [RelayCommand]
    private void SelecionarAba(string aba)
    {
        if (string.IsNullOrWhiteSpace(aba))
            return;

        AbaSelecionada = aba;
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
        await NavegarOuMostrarPlaceholder(nameof(QrCodeScannerPage), "Escanear embarque");
    }

    [RelayCommand]
    private async Task AbrirDetalhe(ReceptionTripItem item)
    {
        if (item is null)
            return;

        await Shell.Current.GoToAsync(nameof(DetalheViagemPage));
    }

    [RelayCommand]
    private async Task AbrirMapa(ReceptionTripItem item)
    {
        if (item is null)
            return;

        await Shell.Current.GoToAsync(nameof(MapaViagemPage));
    }

    [RelayCommand]
    private async Task AbrirItemMenu(SideMenuItem item)
    {
        if (item is null || string.IsNullOrWhiteSpace(item.Rota))
            return;

        MenuAberto = false;

        if (item.Rota == nameof(MinhasViagensPage))
            return;

        await NavegarOuMostrarPlaceholder(item.Rota, item.Titulo);
    }

    [RelayCommand]
    private async Task IrInicio()
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }

    [RelayCommand]
    private Task IrViagens()
    {
        return Task.CompletedTask;
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