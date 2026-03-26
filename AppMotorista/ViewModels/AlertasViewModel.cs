using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMotorista.Models;
using AppMotorista.Pages;

namespace AppMotorista.ViewModels;

public partial class AlertasViewModel : ObservableObject
{
    [ObservableProperty] private string tituloPagina = "Alertas e Ocorrências";
    [ObservableProperty] private string resumo = "2 alertas ativos • 1 ocorrência registrada";

    public ObservableCollection<AlertaItem> AlertasAtivos { get; } = new();
    public ObservableCollection<AlertaItem> OcorrenciasRecentes { get; } = new();

    public AlertasViewModel()
    {
        AlertasAtivos.Add(new AlertaItem
        {
            Titulo = "Passageiro pendente",
            Descricao = "Ainda há passageiro sem confirmação de embarque na viagem 07:40.",
            DataHora = "Hoje • 07:25",
            Severidade = "Atenção",
            CorFundo = "#FFF4E5",
            CorTexto = "#B96A00",
            Origem = "Embarque"
        });

        AlertasAtivos.Add(new AlertaItem
        {
            Titulo = "Rota com atraso",
            Descricao = "Deslocamento até o Hospital Ana Nery está acima do previsto.",
            DataHora = "Hoje • 08:02",
            Severidade = "Alta",
            CorFundo = "#FDECEC",
            CorTexto = "#C62828",
            Origem = "Mapa da viagem"
        });

        OcorrenciasRecentes.Add(new AlertaItem
        {
            Titulo = "Ausência registrada",
            Descricao = "Paciente Ana Luiza marcado como ausente no ponto de embarque.",
            DataHora = "Hoje • 07:18",
            Severidade = "Registro",
            CorFundo = "#EAF2FF",
            CorTexto = "#2357C6",
            Origem = "Embarque"
        });
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task NovaOcorrencia()
    {
        await Shell.Current.GoToAsync(nameof(OcorrenciaFormPage));
    }

    [RelayCommand]
    private async Task AbrirItem(AlertaItem item)
    {
        if (item is null) return;

        await Shell.Current.DisplayAlertAsync(
            item.Titulo,
            $"{item.Descricao}\n\nOrigem: {item.Origem}\nNível: {item.Severidade}\nQuando: {item.DataHora}",
            "OK");
    }
}