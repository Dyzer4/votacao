using Microsoft.EntityFrameworkCore;
using VotacaoAPI.Data;
using VotacaoAPI.DTO;

namespace VotacaoAPI.Services
{
    public class CandidatoService
    {
        private readonly CIPAContext _context;

        public CandidatoService(CIPAContext context)
        {
            _context = context;
        }

        public async Task<List<CandidatoAprovadoDto>> ListarAprovadosPorCipaAsync(int idCipa)
        {
            return await _context.Candidatos
                .Where(c => c.IdCipa == idCipa && c.StatusDaInscricao == "Aprovada")
                .Include(c => c.Colaborador)
                .Select(c => new CandidatoAprovadoDto
                {
                    IdCandidato = c.IdCandidato,
                    NomeColaborador = c.Colaborador.NomeCompleto,
                    AreaOuSetor = c.AreaOuSetor,
                    URLDaFoto = c.URLDaFoto
                })
                .ToListAsync();
        }

        public async Task<List<CandidatoAprovadoDto>> ListarTodosCandidatosPorCipa(int idCipa)
        {
            return await _context.Candidatos
                .Where(c => c.IdCipa == idCipa)
                .Include(c => c.Colaborador)
                .Select(c => new CandidatoAprovadoDto
                {
                    IdCandidato = c.IdCandidato,
                    NomeColaborador = c.Colaborador.NomeCompleto,
                    AreaOuSetor = c.AreaOuSetor,
                    URLDaFoto = c.URLDaFoto
                })
                .ToListAsync();
        }
        
    }
}