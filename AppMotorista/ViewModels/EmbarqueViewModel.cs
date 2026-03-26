using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Pages;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class EmbarqueViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Embarque";
    [ObservableProperty] private string destino = "Hospital Ana Nery";
    [ObservableProperty] private string horario = "07:40";
    [ObservableProperty] private string veiculo = "Citroën Jumpy - QWE-1234";
    [ObservableProperty] private string resumo = "3 passageiros • 1 acompanhante";
    [ObservableProperty] private string statusGeral = "Aguardando embarque";

    public ObservableCollection<PassengerBoardingItem> Passageiros { get; } = new();

    public EmbarqueViewModel()
    {
        Passageiros.Add(new PassengerBoardingItem
        {
            Nome = "Maria Aparecida",
            Acompanhante = "Sem acompanhante",
            Status = "Pendente",
            StatusCorFundo = "#FFF4E5",
            StatusCorTexto = "#B96A00"
        });

        Passageiros.Add(new PassengerBoardingItem
        {
            Nome = "José Carlos",
            Acompanhante = "Acompanhante: Joana Carlos",
            Status = "Embarcado",
            StatusCorFundo = "#E8F6EC",
            StatusCorTexto = "#239B56"
        });

        Passageiros.Add(new PassengerBoardingItem
        {
            Nome = "Ana Luiza",
            Acompanhante = "Sem acompanhante",
            Status = "Pendente",
            StatusCorFundo = "#FFF4E5",
            StatusCorTexto = "#B96A00"
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task LerQrCode()
    {
        await Shell.Current.GoToAsync(nameof(QrCodeScannerPage));
    }

    [RelayCommand]
    private void MarcarEmbarcado(PassengerBoardingItem item)
    {
        if (item is null) return;

        item.Status = "Embarcado";
        item.StatusCorFundo = "#E8F6EC";
        item.StatusCorTexto = "#239B56";

        AtualizarLista();
    }

    [RelayCommand]
    private void MarcarAusente(PassengerBoardingItem item)
    {
        if (item is null) return;

        item.Status = "Ausente";
        item.StatusCorFundo = "#FDECEC";
        item.StatusCorTexto = "#C62828";

        AtualizarLista();
    }

    [RelayCommand]
    private async Task ConfirmarEmbarque()
    {
        await Shell.Current.DisplayAlertAsync(
            "Embarque confirmado",
            "O embarque foi confirmado no fluxo mockado.",
            "OK");
    }

    private void AtualizarLista()
    {
        var itens = Passageiros.ToList();
        Passageiros.Clear();

        foreach (var item in itens)
            Passageiros.Add(item);
    }
}