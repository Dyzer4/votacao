using Microsoft.EntityFrameworkCore;
using VotacaoAPI.Model;

namespace VotacaoAPI.Data
{
    public class CIPAContext : DbContext
    {
        public CIPAContext(DbContextOptions<CIPAContext> options)
            : base(options)
        {
        }

        public DbSet<EmpresaModel> Empresas { get; set; }
        public DbSet<ColaboradorModel> Colaboradores { get; set; }
        public DbSet<CipaModel> Cipas { get; set; }
        public DbSet<VotoModel> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========================
            // ===== EMPRESA ==========
            // ========================
            modelBuilder.Entity<EmpresaModel>(entity =>
            {
                entity.HasIndex(e => e.CNPJ).IsUnique();

                entity.HasCheckConstraint("CK_EMPRESA_Status",
                    "Status IN ('Ativa', 'Inativa')");

                entity.HasMany(e => e.Colaboradores)
                      .WithOne(c => c.Empresa)
                      .HasForeignKey(c => c.IdEmpresa)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Cipas)
                      .WithOne(c => c.Empresa)
                      .HasForeignKey(c => c.IdEmpresa)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ========================
            // ==== COLABORADOR =======
            // ========================
            modelBuilder.Entity<ColaboradorModel>(entity =>
            {
                entity.HasIndex(c => c.EmailCorporativo)
                      .IsUnique()
                      .HasFilter("[EmailCorporativo] IS NOT NULL");

                entity.HasCheckConstraint("CK_COLABORADOR_Status",
                    "Status IN ('Ativo', 'Inativo', 'Demitido')");

                entity.HasOne(c => c.Atualizador)
                      .WithMany()
                      .HasForeignKey(c => c.MatriculaDoAtualizador)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ========================
            // ======== CIPA ==========
            // ========================
            modelBuilder.Entity<CipaModel>(entity =>
            {
                entity.HasIndex(c => c.CodigoDaGestao)
                      .IsUnique();

                entity.HasCheckConstraint("CK_CIPA_Status",
                    "Status IN ('Configuracao', 'Ativa', 'Votacao', 'Apuracao', 'Finalizada', 'Cancelada')");

                entity.HasOne(c => c.Empresa)
                      .WithMany(e => e.Cipas)
                      .HasForeignKey(c => c.IdEmpresa)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Criador)
                      .WithMany(c => c.CipasCriadas)
                      .HasForeignKey(c => c.MatriculaDoCriador)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ========================
            // ========= VOTO =========
            // ========================
            modelBuilder.Entity<VotoModel>(entity =>
            {
                entity.HasIndex(v => v.HashDoVoto)
                      .IsUnique();

                entity.HasIndex(v => v.ProtocoloDoVoto)
                      .IsUnique()
                      .HasFilter("[ProtocoloDoVoto] IS NOT NULL");

                entity.HasOne(v => v.Cipa)
                      .WithMany(c => c.Votos)
                      .HasForeignKey(v => v.IdCipa)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(v => v.Colaborador)
                      .WithMany(c => c.Votos)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            
            // ========================
            // ===== CANDIDATO ========
            // ========================
            modelBuilder.Entity<CandidatoModel>(entity =>
            {
                entity.HasCheckConstraint("CK_CANDIDATO_StatusDaInscricao",
                    "StatusDaInscricao IN ('Pendente', 'Aprovada', 'Rejeitada')");

                entity.HasOne(c => c.Cipa)
                    .WithMany(c => c.Candidatos)
                    .HasForeignKey(c => c.IdCipa)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Colaborador)
                    .WithMany(c => c.Candidaturas)
                    .HasForeignKey(c => c.MatriculaColaborador)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
