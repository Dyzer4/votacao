using VotacaoAPI.DTO;

namespace VotacaoAPI.interfaces;

public interface IVotacaoService
{
    public Task RegistrarVotos(VotoRequest votoRequest);
}