using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace api_development.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O valor deve ser inserido")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public float Valor { get; set; }

        [Required(ErrorMessage = "O pagamento deve ter um cartão cadastrado")]
        [NotMapped]
        public Cartao Cartao { get; set; }
    }

    [Keyless]
    public class StatusCompra 
    {
        public float Valor { get; set; }
        public string Estado { get; set; }

        public StatusCompra(float Valor, string Estado)
        {
            this.Valor = Valor;
            this.Estado = Estado;
        }
    }
}
