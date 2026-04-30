namespace AppMotorista.Models;

public class SideMenuItem
{
    public string Titulo { get; set; } = string.Empty;
    public string Icone { get; set; } = string.Empty;
    public string Rota { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public string CorFundo => Ativo ? "#EEF3FF" : "Transparent";
    public string CorTexto => Ativo ? "#2357C6" : "#374151";
}