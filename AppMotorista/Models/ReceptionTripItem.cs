namespace AppMotorista.Models;

public class ReceptionTripItem
{
    public string Data { get; set; } = string.Empty;
    public string Horario { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public string Veiculo { get; set; } = string.Empty;
    public string Motorista { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool TravaFaturamentoAtiva { get; set; }
    // novas adições / teste
    public string ResumoRota { get; set; } = string.Empty;
    public string ResumoPassageiros { get; set; } = string.Empty;
    public string EquipeApoio { get; set; } = string.Empty;
    public string VeiculoDetalhe { get; set; } = string.Empty;

}