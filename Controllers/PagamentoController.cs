using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_development.Data;
using api_development.Models;
using System;

namespace api_development.Controllers
{
    [Route("api/pagamento")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        [HttpPost]
        [Route("compras")]
        public ActionResult Post([FromServices] DataContext context, [FromBody] Pagamento model)
        {
            if (model.Cartao.CreditCard_Evaluation() == 1) // Se o cartão é válido.
            {

                String estado;

                if (model.Valor > 100)
                {
                    estado = "APROVADO";
                }
                else
                {
                    estado = "REJEITADO";
                }

                StatusCompra statusCompra = new StatusCompra(model.Valor, estado);

                return Ok(statusCompra);
            }
            else // Se o cartão NÃO for válido.
            {
                var saida = new
                {
                    codigo = "400",
                    resposta = "O cartão de crédito não é válido"
                };
                return BadRequest(saida);
            }
        }

    }
}
