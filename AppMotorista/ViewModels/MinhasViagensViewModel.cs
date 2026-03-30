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
            TravaFaturamentoAtiva = true,

            // complementares
            ResumoRota = "Origem: UBS Central • Parada: Avenida Brasil",
            ResumoPassageiros = "3 passageiros • 1 acompanhante",
            EquipeApoio = "Juliana Costa • Técnica de Enfermagem",
            VeiculoDetalhe = "Placa QWE-1234 • Diesel • 4 lugares"
        });

        Confirmadas.Add(new ReceptionTripItem
        {
            Data = "24/04/2024",
            Horario = "09:20",
            Destino = "Policlínica Regional Oeste",
            Veiculo = "Renault Master",
            Motorista = "Gabriel Almeida",
            Status = "Confirmada",
            TravaFaturamentoAtiva = false,

            ResumoRota = "Origem: UBS Barreiro • Parada: Rua Pará",
            ResumoPassageiros = "2 passageiros • 0 acompanhantes",
            EquipeApoio = "Sem equipe de apoio",
            VeiculoDetalhe = "Placa RTY-9087 • Diesel • 3 lugares"
        });

        EmAndamento.Add(new ReceptionTripItem
        {
            Data = "24/04/2024",
            Horario = "08:10",
            Destino = "Unidade São José",
            Veiculo = "Ford Transit",
            Motorista = "Gabriel Almeida",
            Status = "Em andamento",
            TravaFaturamentoAtiva = true,

            ResumoRota = "Origem: UBS Centro-Sul • Parada: Rua da Bahia",
            ResumoPassageiros = "4 passageiros • 1 acompanhante",
            EquipeApoio = "Marcos Vinícius • Maqueiro",
            VeiculoDetalhe = "Placa HJK-4521 • Diesel • 5 lugares"
        });

        Finalizadas.Add(new ReceptionTripItem
        {
            Data = "23/04/2024",
            Horario = "14:00",
            Destino = "Hospital Municipal",
            Veiculo = "Citroën Jumpy",
            Motorista = "Gabriel Almeida",
            Status = "Finalizada",
            TravaFaturamentoAtiva = false,

            ResumoRota = "Origem: UBS Central • Destino direto",
            ResumoPassageiros = "1 passageiro • 0 acompanhantes",
            EquipeApoio = "Sem equipe de apoio",
            VeiculoDetalhe = "Placa QWE-1234 • Diesel • 4 lugares"
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