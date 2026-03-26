using AppMotorista.Pages;

namespace AppMotorista
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(MinhasViagensPage), typeof(MinhasViagensPage));
            Routing.RegisterRoute(nameof(PlanejamentoRotasPage), typeof(PlanejamentoRotasPage));
            Routing.RegisterRoute(nameof(CadastroVeiculosPage), typeof(CadastroVeiculosPage));
            Routing.RegisterRoute(nameof(LocaisPage), typeof(LocaisPage));
            Routing.RegisterRoute(nameof(AgrupamentoPacientesPage), typeof(AgrupamentoPacientesPage));
            Routing.RegisterRoute(nameof(EquipeApoioPage), typeof(EquipeApoioPage));
            Routing.RegisterRoute(nameof(AlertasPage), typeof(AlertasPage));
            Routing.RegisterRoute(nameof(ConfigPage), typeof(ConfigPage));
            Routing.RegisterRoute(nameof(SuportePage), typeof(SuportePage));
            Routing.RegisterRoute(nameof(OcorrenciaFormPage), typeof(OcorrenciaFormPage));
            Routing.RegisterRoute(nameof(DetalheViagemPage), typeof(DetalheViagemPage));
            Routing.RegisterRoute(nameof(MapaViagemPage), typeof(MapaViagemPage));
            Routing.RegisterRoute(nameof(EmbarquePage), typeof(EmbarquePage));
            Routing.RegisterRoute(nameof(QrCodeScannerPage), typeof(QrCodeScannerPage));
        }
    }
}