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

    [ObservableProperty] private string capacidadeVeiculo = "4 lugares";
    [ObservableProperty] private int capacidadeMaxima = 4;
    [ObservableProperty] private int totalPassageiros = 3;
    [ObservableProperty] private int totalAcompanhantes = 1;

    [ObservableProperty] private string ocupacaoResumo = "Ocupação atual: 2 de 4";
    [ObservableProperty] private bool exibirAlertaLotacao;
    [ObservableProperty] private string alertaLotacaoTitulo = "Lotação da rota";
    [ObservableProperty] private string alertaLotacaoDescricao = "A ocupação atual está dentro da capacidade do veículo.";

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

        AtualizarResumoOperacional();
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
        AtualizarResumoOperacional();
    }

    [RelayCommand]
    private void MarcarAusente(PassengerBoardingItem item)
    {
        if (item is null) return;

        item.Status = "Ausente";
        item.StatusCorFundo = "#FDECEC";
        item.StatusCorTexto = "#C62828";

        AtualizarLista();
        AtualizarResumoOperacional();
    }

    [RelayCommand]
    private void MarcarDesembarcado(PassengerBoardingItem item)
    {
        if (item is null) return;

        item.Status = "Desembarcado";
        item.StatusCorFundo = "#EAF3FF";
        item.StatusCorTexto = "#2357C6";

        AtualizarLista();
        AtualizarResumoOperacional();
    }

    [RelayCommand]
    private async Task ConfirmarEmbarque()
    {
        AtualizarResumoOperacional();

        await Shell.Current.DisplayAlertAsync(
            "Embarque confirmado",
            "O embarque foi confirmado no fluxo mockado.",
            "OK");
    }

    private void AtualizarResumoOperacional()
    {
        var embarcados = Passageiros.Count(x => x.Status == "Embarcado");
        var ausentes = Passageiros.Count(x => x.Status == "Ausente");
        var desembarcados = Passageiros.Count(x => x.Status == "Desembarcado");
        var pendentes = Passageiros.Count(x => x.Status == "Pendente");

        var ocupacaoAtual = embarcados + TotalAcompanhantes;
        OcupacaoResumo = $"Ocupação atual: {ocupacaoAtual} de {CapacidadeMaxima}";

        if (desembarcados == Passageiros.Count && Passageiros.Count > 0)
        {
            StatusGeral = "Viagem finalizada";
        }
        else if (embarcados > 0 && pendentes > 0)
        {
            StatusGeral = "Embarque em andamento";
        }
        else if (embarcados > 0 && pendentes == 0)
        {
            StatusGeral = "Embarque concluído";
        }
        else if (ausentes > 0 && embarcados == 0)
        {
            StatusGeral = "Embarque com ausência";
        }
        else
        {
            StatusGeral = "Aguardando embarque";
        }

        Resumo = $"{TotalPassageiros} passageiros • {TotalAcompanhantes} acompanhante(s)";

        if (ocupacaoAtual > CapacidadeMaxima)
        {
            ExibirAlertaLotacao = true;
            AlertaLotacaoTitulo = "Capacidade excedida";
            AlertaLotacaoDescricao = "A quantidade total de passageiros e acompanhantes ultrapassa a capacidade do veículo.";
        }
        else if (ocupacaoAtual == CapacidadeMaxima)
        {
            ExibirAlertaLotacao = true;
            AlertaLotacaoTitulo = "Capacidade máxima atingida";
            AlertaLotacaoDescricao = "A ocupação atual atingiu o limite do veículo.";
        }
        else
        {
            ExibirAlertaLotacao = false;
            AlertaLotacaoTitulo = "Lotação da rota";
            AlertaLotacaoDescricao = "A ocupação atual está dentro da capacidade do veículo.";
        }
    }

    private void AtualizarLista()
    {
        var itens = Passageiros.ToList();
        Passageiros.Clear();

        foreach (var item in itens)
            Passageiros.Add(item);
    }
}