using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class PlanejamentoRotasViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Planejamento de Rotas";
    [ObservableProperty] private string filtroData = "24/04/2024";

    public ObservableCollection<RoutePlanningItem> Rotas { get; } = new();

    public PlanejamentoRotasViewModel()
    {
        Rotas.Add(new RoutePlanningItem
        {
            Data = "24/04/2024",
            Horario = "07:40",
            Destino = "Hospital Ana Nery",
            Veiculo = "Citroën Jumpy",
            QuantidadePacientes = "4 pacientes",
            Status = "Planejada"
        });

        Rotas.Add(new RoutePlanningItem
        {
            Data = "24/04/2024",
            Horario = "08:20",
            Destino = "Policlínica Regional Oeste",
            Veiculo = "Renault Master",
            QuantidadePacientes = "2 pacientes",
            Status = "Pendente"
        });

        Rotas.Add(new RoutePlanningItem
        {
            Data = "24/04/2024",
            Horario = "09:10",
            Destino = "UBS São José",
            Veiculo = "Ford Transit",
            QuantidadePacientes = "5 pacientes",
            Status = "Confirmada"
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task NovaRota()
    {
        await Shell.Current.DisplayAlertAsync("Rota", "Criar nova rota", "OK");
    }

    [RelayCommand]
    private async Task AbrirRota(RoutePlanningItem item)
    {
        if (item is null) return;
        await Shell.Current.DisplayAlertAsync("Rota", $"Destino: {item.Destino}", "OK");
    }
}