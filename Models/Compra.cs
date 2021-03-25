using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_development.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A compra deve ter um id do produto.")]
        public int Produto_id { get; set; }

        [Required(ErrorMessage = "A quantidade de itens comprados deve ser informado.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Qtde_comprada { get; set; }

        [Required(ErrorMessage = "A compra deve ter um cartão cadastrado")]
        [NotMapped]
        public Cartao Cartao { get; set; }
    }
}
