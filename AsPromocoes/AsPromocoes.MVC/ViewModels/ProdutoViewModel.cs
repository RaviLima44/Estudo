﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AsPromocoes.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int produtoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage ="Preencha um valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponivel?")]
        public bool Disponivel { get; set; }

        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}