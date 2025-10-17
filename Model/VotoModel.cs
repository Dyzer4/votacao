namespace VotacaoAPI.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("VOTO")]
public class VotoModel
{
        [Key] [Column("IdVoto")] public int IdVoto { get; set; }

        [Required] [Column("IdCipa")] public int IdCipa { get; set; }

        [Column("IdCandidatoVotado")] public int? IdCandidatoVotado { get; set; }

        [Required]
        [Column("VotoCriptografado", TypeName = "varbinary(max)")]
        public byte[] VotoCriptografado { get; set; } = Array.Empty<byte>();

        [Required]
        [Column("HashDoVoto")]
        [StringLength(128)]
        public string HashDoVoto { get; set; } = string.Empty;

        [Required]
        [Column("DataHoraDoVoto", TypeName = "datetime2(3)")]
        public DateTime DataHoraDoVoto { get; set; }

        [Column("DataHoraRandomizadaDoVoto", TypeName = "datetime2(3)")]
        public DateTime? DataHoraRandomizadaDoVoto { get; set; }

        [Column("ProtocoloDoVoto")]
        [StringLength(100)]
        public string? ProtocoloDoVoto { get; set; }

        [Column("IdentificadorDoDispositivo")]
        [StringLength(50)]
        public string? IdentificadorDoDispositivo { get; set; }
        
        [Column("TipoVoto")]
        public Boolean TipoVoto { get; set; }

        // ====== RELACIONAMENTOS ======

        [ForeignKey(nameof(IdCipa))] public virtual CipaModel? Cipa { get; set; }
        
        public virtual ColaboradorModel? Colaborador { get; set; }

}