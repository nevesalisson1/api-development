using System;
using System.ComponentModel.DataAnnotations;


namespace api_development.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O produto deve ter um nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O produto deve ter um valor válido.")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public float Valor_unitario { get; set; }

        [Required(ErrorMessage = "Deve ser informada a quantidade em estoque do produto.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual que zero" )]
        public int Qtde_estoque { get; set; }

        public float? Valor_ultima_venda { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Data_ultima_venda { get; set; }

    }
}
