namespace VotacaoAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    [Table("EMPRESA")]
    public class EmpresaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdEmpresa")]
        public int IdEmpresa { get; set; }

        [Required]
        [Column("CNPJ")]
        [StringLength(18)]
        public string CNPJ { get; set; } = string.Empty;

        [Required]
        [Column("RazaoSocial")]
        [StringLength(100)]
        public string RazaoSocial { get; set; } = string.Empty;

        [Required]
        [Column("DataDeCadastro", TypeName = "datetime2(3)")]
        public DateTime DataDeCadastro { get; set; }

        [Required]
        [Column("Status")]
        [StringLength(20)]
        public string Status { get; set; } = "Ativa";

        // ====== RELACIONAMENTOS ======
        public virtual ICollection<ColaboradorModel> Colaboradores { get; set; } = new List<ColaboradorModel>();
        public virtual ICollection<CipaModel> Cipas { get; set; } = new List<CipaModel>();
    }
