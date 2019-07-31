using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Senai.CodeTur.Servico.ViewModels
{
    public class PacoteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título do pacote")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe a descricao do pacote")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a url da imagem do pacote")]
        public string UrlImagem { get; set; }

        [Required(ErrorMessage = "Informe a Data de Início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Informe a Data Final")]
        public DateTime DataFim { get; set; }

        public bool Ativo { get; set; }
    }
}