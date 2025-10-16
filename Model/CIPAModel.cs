namespace VotacaoAPI.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    [Table("CIPA")]
    public class CipaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCipa")]
        public int IdCipa { get; set; }

        [Required]
        [Column("IdEmpresa")]
        public int IdEmpresa { get; set; }

        [Required]
        [Column("CodigoDaGestao")]
        [StringLength(50)]
        public string CodigoDaGestao { get; set; } = string.Empty;

        [Required]
        [Column("Descricao")]
        [StringLength(255)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [Column("DataDeInicioDaGestao", TypeName = "datetime2(3)")]
        public DateTime DataDeInicioDaGestao { get; set; }

        [Required]
        [Column("DataDeFimDaGestao", TypeName = "datetime2(3)")]
        public DateTime DataDeFimDaGestao { get; set; }

        [Column("MatriculaDoCriador")]
        [StringLength(50)]
        public string? MatriculaDoCriador { get; set; }

        [Column("DataDeAberturaDaVotacao", TypeName = "datetime2(3)")]
        public DateTime? DataDeAberturaDaVotacao { get; set; }

        [Column("DataDeFechamentoDaVotacao", TypeName = "datetime2(3)")]
        public DateTime? DataDeFechamentoDaVotacao { get; set; }

        [Required]
        [Column("DataDeCadastro", TypeName = "datetime2(3)")]
        public DateTime DataDeCadastro { get; set; }

        [Required]
        [Column("Status")]
        [StringLength(20)]
        public string Status { get; set; } = "Configuracao";

        [ForeignKey(nameof(IdEmpresa))]
        public virtual EmpresaModel? Empresa { get; set; }

        [ForeignKey(nameof(MatriculaDoCriador))]
        public virtual ColaboradorModel? Criador { get; set; }

        public virtual ICollection<VotoModel> Votos { get; set; } = new List<VotoModel>();
        public ICollection<CandidatoModel> Candidatos { get; set; } = new List<CandidatoModel>();

    }