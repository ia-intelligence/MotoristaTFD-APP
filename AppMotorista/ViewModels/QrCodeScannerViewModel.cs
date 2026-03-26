using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class QrCodeScannerViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Leitura de QR Code";
    [ObservableProperty] private string instrucao = "Posicione o QR Code do passageiro dentro da área de leitura.";
    [ObservableProperty] private bool passageiroValidado;
    [ObservableProperty] private string nomePassageiro = "-";
    [ObservableProperty] private string detalhePassageiro = "-";
    [ObservableProperty] private string statusLeitura = "Aguardando leitura";
    [ObservableProperty] private bool lendoQrCode = true;
    [ObservableProperty] private bool leituraConcluida;
    [ObservableProperty] private bool cameraDisponivel = true;
    [ObservableProperty] private string qrLido = string.Empty;

    public bool PodeConfirmar => PassageiroValidado && !LendoQrCode;

    partial void OnPassageiroValidadoChanged(bool value)
    {
        OnPropertyChanged(nameof(PodeConfirmar));
    }

    partial void OnLendoQrCodeChanged(bool value)
    {
        OnPropertyChanged(nameof(PodeConfirmar));
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private void NovaLeitura()
    {
        PassageiroValidado = false;
        LeituraConcluida = false;
        LendoQrCode = true;
        QrLido = string.Empty;
        NomePassageiro = "-";
        DetalhePassageiro = "-";
        StatusLeitura = "Aguardando leitura";
    }

    [RelayCommand]
    private async Task ConfirmarEmbarque()
    {
        if (!PassageiroValidado)
        {
            await Shell.Current.DisplayAlertAsync(
                "QR Code",
                "Faça a leitura do passageiro antes de confirmar o embarque.",
                "OK");
            return;
        }

        await Shell.Current.DisplayAlertAsync(
            "Embarque confirmado",
            $"{NomePassageiro} foi confirmado no fluxo mockado.",
            "OK");

        await Shell.Current.Navigation.PopAsync();
    }

    public void DefinirCameraIndisponivel()
    {
        CameraDisponivel = false;
        LendoQrCode = false;
        StatusLeitura = "Câmera não disponível neste dispositivo";
    }

    public void ProcessarQrCode(string valorQr)
    {
        if (string.IsNullOrWhiteSpace(valorQr))
            return;

        QrLido = valorQr;
        LendoQrCode = false;
        LeituraConcluida = true;
        PassageiroValidado = true;
        StatusLeitura = "QR Code validado com sucesso";

        // Mock simples por enquanto:
        NomePassageiro = "Maria Aparecida";
        DetalhePassageiro = $"QR: {valorQr}";
    }
}