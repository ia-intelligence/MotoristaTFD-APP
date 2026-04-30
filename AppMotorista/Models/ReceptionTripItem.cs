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
    public string DataHorario => $"{Data} - {Horario}";

    public string Origem
    {
        get
        {
            if (string.IsNullOrWhiteSpace(ResumoRota))
                return "Terminal Integrado Central";

            var partes = ResumoRota.Split('•');
            return partes.Length > 0 ? partes[0].Trim() : ResumoRota;
        }
    }

    public string DestinoEndereco
    {
        get
        {
            if (string.IsNullOrWhiteSpace(ResumoRota))
                return Destino;

            var partes = ResumoRota.Split('•');
            return partes.Length > 1 ? partes[1].Trim() : Destino;
        }
    }

    public string VeiculoProprioTexto => TravaFaturamentoAtiva ? "Veículo próprio" : "Retorno: 17:00";

    public string IniciaisMotorista
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Motorista))
                return "M";

            var partes = Motorista.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length == 1)
                return partes[0][0].ToString().ToUpper();

            return $"{partes[0][0]}{partes[^1][0]}".ToUpper();
        }
    }
}