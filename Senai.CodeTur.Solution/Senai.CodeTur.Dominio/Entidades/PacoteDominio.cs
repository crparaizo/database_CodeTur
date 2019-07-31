using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Senai.CodeTur.Dominio.Entidades
{
    [Table("Pacotes")]
    public class PacoteDominio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Titulo", TypeName = "varchar(100)")]
        [Required]
        public string Titulo { get; set; }

        [Column("Descricao", TypeName = "Text")]
        [Required]
        public string Descricao { get; set; }

        [Column("UrlImagem", TypeName = "varchar(250)")]
        [Required]
        public string UrlImagem { get; set; }

        [Column("DataInicio", TypeName = "DATE")]
        [Required]
        public DateTime DataInicio { get; set; }

        [Column("DataFim", TypeName = "DATE")]
        [Required]
        public DateTime DataFim { get; set; }

        [Column("Ativo", TypeName = "bit")]
        public bool Ativo { get; set; }
    }
}
