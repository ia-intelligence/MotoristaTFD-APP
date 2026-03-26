using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class CadastroVeiculosViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Veículos e Motoristas";

    public ObservableCollection<FleetItem> Itens { get; } = new();

    public CadastroVeiculosViewModel()
    {
        Itens.Add(new FleetItem
        {
            Veiculo = "Citroën Jumpy",
            Placa = "QWE-1234",
            Combustivel = "Diesel",
            Motorista = "Gabriel Almeida",
            Capacidade = "8 lugares"
        });

        Itens.Add(new FleetItem
        {
            Veiculo = "Renault Master",
            Placa = "ABC-5678",
            Combustivel = "Diesel",
            Motorista = "João Carlos",
            Capacidade = "15 lugares"
        });

        Itens.Add(new FleetItem
        {
            Veiculo = "Ford Transit",
            Placa = "XYZ-9012",
            Combustivel = "Gasolina",
            Motorista = "Marcos Silva",
            Capacidade = "12 lugares"
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task NovoCadastro()
    {
        await Shell.Current.DisplayAlertAsync("Cadastro", "Novo veículo/motorista", "OK");
    }

    [RelayCommand]
    private async Task AbrirItem(FleetItem item)
    {
        if (item is null) return;
        await Shell.Current.DisplayAlertAsync("Veículo", $"{item.Veiculo} - {item.Placa}", "OK");
    }
}