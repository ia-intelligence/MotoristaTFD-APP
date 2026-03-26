using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;

namespace AppMotorista.ViewModels;

public partial class LocaisViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Locais";

    [ObservableProperty]
    private string pesquisa = string.Empty;

    public ObservableCollection<LocationPointItem> Locais { get; } = new();

    public LocaisViewModel()
    {
        Locais.Add(new LocationPointItem
        {
            Nome = "UBS São José",
            Endereco = "Rua das Flores, 120",
            Tipo = "Embarque",
            Cidade = "Belo Horizonte"
        });

        Locais.Add(new LocationPointItem
        {
            Nome = "Hospital Ana Nery",
            Endereco = "Av. Central, 890",
            Tipo = "Destino",
            Cidade = "Belo Horizonte"
        });

        Locais.Add(new LocationPointItem
        {
            Nome = "Policlínica Regional Oeste",
            Endereco = "Rua do Contorno, 455",
            Tipo = "Destino",
            Cidade = "Contagem"
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task NovoLocal()
    {
        await Shell.Current.DisplayAlertAsync("Local", "Cadastrar novo local", "OK");
    }

    [RelayCommand]
    private async Task AbrirLocal(LocationPointItem item)
    {
        if (item is null) return;

        await Shell.Current.DisplayAlertAsync("Local", $"{item.Nome}\n{item.Endereco}", "OK");
    }
}