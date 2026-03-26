using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class EquipeApoioViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Equipe de Apoio";

    public ObservableCollection<SupportTeamItem> Itens { get; } = new();

    public EquipeApoioViewModel()
    {
        Itens.Add(new SupportTeamItem
        {
            Profissional = "Maria Fernanda",
            Funcao = "Técnica de Enfermagem",
            Rota = "Hospital Ana Nery - 07:40",
            Status = "Vinculada"
        });

        Itens.Add(new SupportTeamItem
        {
            Profissional = "Carlos Henrique",
            Funcao = "Maqueiro",
            Rota = "Policlínica Regional Oeste - 08:20",
            Status = "Disponível"
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task NovoVinculo()
    {
        await Shell.Current.DisplayAlertAsync("Equipe", "Novo vínculo de apoio", "OK");
    }

    [RelayCommand]
    private async Task AbrirProfissional(SupportTeamItem item)
    {
        if (item is null) return;

        await Shell.Current.DisplayAlertAsync("Profissional", $"{item.Profissional}\n{item.Funcao}", "OK");
    }
}