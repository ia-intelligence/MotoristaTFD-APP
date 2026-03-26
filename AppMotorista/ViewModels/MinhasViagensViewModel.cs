using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class MinhasViagensViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Minhas Viagens";

    [ObservableProperty]
    private string resumoPagina = "3 viagens no dia • 1 em andamento";

    public ObservableCollection<ReceptionTripItem> Confirmadas { get; } = new();
    public ObservableCollection<ReceptionTripItem> EmAndamento { get; } = new();
    public ObservableCollection<ReceptionTripItem> Finalizadas { get; } = new();

    public MinhasViagensViewModel()
    {
        Confirmadas.Add(new ReceptionTripItem
        {
            Data = "24/04/2024",
            Horario = "07:40",
            Destino = "Hospital Ana Nery",
            Veiculo = "Citroën Jumpy",
            Motorista = "Gabriel Almeida",
            Status = "Confirmada",
            TravaFaturamentoAtiva = true
        });

        Confirmadas.Add(new ReceptionTripItem
        {
            Data = "24/04/2024",
            Horario = "09:20",
            Destino = "Policlínica Regional Oeste",
            Veiculo = "Renault Master",
            Motorista = "Gabriel Almeida",
            Status = "Confirmada",
            TravaFaturamentoAtiva = false
        });

        EmAndamento.Add(new ReceptionTripItem
        {
            Data = "24/04/2024",
            Horario = "08:10",
            Destino = "Unidade São José",
            Veiculo = "Ford Transit",
            Motorista = "Gabriel Almeida",
            Status = "Em andamento",
            TravaFaturamentoAtiva = true
        });

        Finalizadas.Add(new ReceptionTripItem
        {
            Data = "23/04/2024",
            Horario = "14:00",
            Destino = "Hospital Municipal",
            Veiculo = "Citroën Jumpy",
            Motorista = "Gabriel Almeida",
            Status = "Finalizada",
            TravaFaturamentoAtiva = false
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task AbrirDetalhe(ReceptionTripItem item)
    {
        if (item is null) return;

        await Shell.Current.GoToAsync(nameof(DetalheViagemPage));
    }

    [RelayCommand]
    private async Task AbrirMapa(ReceptionTripItem item)
    {
        if (item is null) return;

        await Shell.Current.GoToAsync(nameof(MapaViagemPage));
    }
}