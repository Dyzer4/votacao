using VotacaoAPI.Model;

namespace VotacaoAPI.DTO;

public class VotoRequest
{
    public int IdCandidatoVotado { get; set; }
    
    public int IdCipa { get; set; }

    public Boolean TipoVoto { get; set; }
    
}