using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;


namespace api_development.Models
{
    [Keyless]
    public class Cartao
    {
        [Required(ErrorMessage = "O cartão deve ter um titular.")]
        public string Titular { get; set; }

        [Required(ErrorMessage = "O cartão deve ter um número válido.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Deve ser informada a data de expiração do cartão.")]
        public string Data_expiracao { get; set; }

        [Required(ErrorMessage = "Deve ser informada a bandeira do cartão.")]
        public string Bandeira { get; set; }

        [Required(ErrorMessage = "Deve ser informado o cvv do cartão.")]
        public string Cvv { get; set; }

        internal int CreditCard_Evaluation() // Checa se o cartão é válido, retora 1 se válido, retorna 0 se não válido.
        {
            return 1;
        }
    }
}
