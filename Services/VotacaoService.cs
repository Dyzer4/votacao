using AutoMapper;
using VotacaoAPI.Data;
using VotacaoAPI.DTO;
using VotacaoAPI.exceptions;
using VotacaoAPI.interfaces;
using VotacaoAPI.Model;

namespace VotacaoAPI.Services
{

    public class VotacaoService : IVotacaoService
    {
        private readonly CIPAContext _context;
        private readonly IMapper _imapper;

        public VotacaoService(CIPAContext context, IMapper imapper)
        {
            _context = context;
            _imapper = imapper;
        }

        public async Task RegistrarVotos(VotoRequest votoRequest)
        {
           var cipa = await _context.Cipas.FindAsync(votoRequest.IdCipa);
           var candidato = await _context.Candidatos.FindAsync(votoRequest.IdCandidatoVotado);
           if (cipa == null)
           {
               throw new NaoEncontradoException($"Cipa com id {votoRequest.IdCipa} não encontrada");
           }

           if (candidato == null)
           {
               throw new NaoEncontradoException($"Candidato com id {votoRequest.IdCandidatoVotado} não encontrado");
           }

           VotoModel votoModel = _imapper.Map<VotoModel>(votoRequest);

           await _context.Votos.AddAsync(votoModel);
           await _context.SaveChangesAsync();
        }
    }
    
}
