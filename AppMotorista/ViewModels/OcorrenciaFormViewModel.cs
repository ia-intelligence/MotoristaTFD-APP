using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMotorista.ViewModels;

public partial class OcorrenciaFormViewModel : ObservableObject
{
    [ObservableProperty]
    private string tituloPagina = "Nova Ocorrência";

    [ObservableProperty]
    private string tipoOcorrencia = "Atraso";

    [ObservableProperty]
    private string prioridade = "Alta";

    [ObservableProperty]
    private string viagemRelacionada = "VGM-2024-018";

    [ObservableProperty]
    private string localOcorrencia = "Trecho próximo à Policlínica Oeste";

    [ObservableProperty]
    private string descricao = "Interdição parcial da via, impactando o tempo estimado de chegada.";

    [ObservableProperty]
    private string observacoes = "Motorista comunicou situação via central.";

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Salvar()
    {
        await Shell.Current.DisplayAlertAsync(
            "Ocorrência registrada",
            "A ocorrência foi salva no fluxo mockado com sucesso.",
            "OK");

        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Cancelar()
    {
        await Shell.Current.GoToAsync("..");
    }
}