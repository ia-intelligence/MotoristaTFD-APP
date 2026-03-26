using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class AgrupamentoPacientesViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Agrupamento de Pacientes";

    public ObservableCollection<PatientGroupItem> Grupos { get; } = new();

    public AgrupamentoPacientesViewModel()
    {
        Grupos.Add(new PatientGroupItem
        {
            Destino = "Hospital Ana Nery",
            Horario = "07:40",
            Quantidade = "4 pacientes + 1 acompanhante",
            Veiculo = "Citroën Jumpy",
            Status = "Agrupado"
        });

        Grupos.Add(new PatientGroupItem
        {
            Destino = "Policlínica Regional Oeste",
            Horario = "08:20",
            Quantidade = "2 pacientes",
            Veiculo = "Renault Master",
            Status = "Pendente"
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task NovoAgrupamento()
    {
        await Shell.Current.DisplayAlertAsync("Agrupamento", "Criar novo agrupamento", "OK");
    }

    [RelayCommand]
    private async Task AbrirGrupo(PatientGroupItem item)
    {
        if (item is null) return;

        await Shell.Current.DisplayAlertAsync("Grupo", $"{item.Destino}\n{item.Quantidade}", "OK");
    }
}