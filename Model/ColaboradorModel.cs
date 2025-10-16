namespace VotacaoAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    [Table("COLABORADOR")]
    public class ColaboradorModel
    {
        [Key]
        [Column("Matricula")]
        [StringLength(50)]
        public string Matricula { get; set; } = string.Empty;

        [Required]
        [Column("IdEmpresa")]
        public int IdEmpresa { get; set; }

        [Column("EmailCorporativo")]
        [StringLength(150)]
        public string? EmailCorporativo { get; set; }

        [Column("HashDaSenha")]
        [StringLength(128)]
        public string? HashDaSenha { get; set; }

        [Column("Salt")]
        [StringLength(64)]
        public string? Salt { get; set; }

        [Required]
        [Column("DataDeAdmissao", TypeName = "date")]
        public DateTime DataDeAdmissao { get; set; }

        [Column("DataDeNascimento", TypeName = "date")]
        public DateTime? DataDeNascimento { get; set; }

        [Column("Cargo")]
        [StringLength(100)]
        public string? Cargo { get; set; }

        [Column("QuantidadeDeMandatosCIPA")]
        public int QuantidadeDeMandatosCIPA { get; set; } = 0;

        [Required]
        [Column("NomeCompleto")]
        [StringLength(100)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Column("EmailDeContatoPessoal")]
        [StringLength(150)]
        public string? EmailDeContatoPessoal { get; set; }

        [Column("TelefoneDeContato")]
        [StringLength(20)]
        public string? TelefoneDeContato { get; set; }

        [Required]
        [Column("DataDeImportacao", TypeName = "datetime2(3)")]
        public DateTime DataDeImportacao { get; set; }

        [Required]
        [Column("Status")]
        [StringLength(20)]
        public string Status { get; set; } = "Ativo";

        [Column("MatriculaDoAtualizador")]
        [StringLength(50)]
        public string? MatriculaDoAtualizador { get; set; }

        // ====== RELACIONAMENTOS ======

        [ForeignKey(nameof(IdEmpresa))]
        public virtual EmpresaModel? Empresa { get; set; }

        // Auto-relacionamento (quem atualizou este colaborador)
        [ForeignKey(nameof(MatriculaDoAtualizador))]
        public virtual ColaboradorModel? Atualizador { get; set; }

        // Relacionamento com CIPA e VOTO
        public virtual ICollection<VotoModel> Votos { get; set; } = new List<VotoModel>();
        public virtual ICollection<CipaModel> CipasCriadas { get; set; } = new List<CipaModel>();
        
        public ICollection<CandidatoModel> Candidaturas { get; set; } = new List<CandidatoModel>();

    }
