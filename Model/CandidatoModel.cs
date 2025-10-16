namespace VotacaoAPI.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    [Table("CANDIDATO")]
    public class CandidatoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidato { get; set; }

        [Required]
        public int IdCipa { get; set; }

        [Required]
        [StringLength(50)]
        public string MatriculaColaborador { get; set; }

        [StringLength(100)]
        public string? AreaOuSetor { get; set; }

        [StringLength(255)]
        public string? URLDaFoto { get; set; }

        [StringLength(500)]
        public string? TextoDaProposta { get; set; }

        [Required]
        public DateTime DataDeInscricao { get; set; }

        [StringLength(20)]
        public string StatusDaInscricao { get; set; } = "Pendente";

        // =====================
        // ===== RELAÇÕES ======
        // =====================

        [ForeignKey(nameof(IdCipa))]
        public virtual CipaModel Cipa { get; set; }

        [ForeignKey(nameof(MatriculaColaborador))]
        public virtual ColaboradorModel Colaborador { get; set; }
    }