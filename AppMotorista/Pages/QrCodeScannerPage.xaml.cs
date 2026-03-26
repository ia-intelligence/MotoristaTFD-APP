using AppMotorista.ViewModels;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace AppMotorista.Pages;

public partial class QrCodeScannerPage : ContentPage
{
    private QrCodeScannerViewModel Vm => (QrCodeScannerViewModel)BindingContext;
    private bool _codigoJaProcessado;

    public QrCodeScannerPage()
    {
        InitializeComponent();
        BindingContext = new QrCodeScannerViewModel();

        if (!BarcodeScanning.IsSupported)
        {
            Vm.DefinirCameraIndisponivel();
            return;
        }

        barcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false
        };

        barcodeReader.BarcodesDetected += OnBarcodesDetected;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _codigoJaProcessado = false;
    }

    private void OnBarcodesDetected(object? sender, BarcodeDetectionEventArgs e)
    {
        if (_codigoJaProcessado)
            return;

        var resultado = e.Results?.FirstOrDefault();
        if (resultado is null || string.IsNullOrWhiteSpace(resultado.Value))
            return;

        _codigoJaProcessado = true;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Vm.ProcessarQrCode(resultado.Value);
        });
    }
}