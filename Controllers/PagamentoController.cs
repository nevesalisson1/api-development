using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_development.Data;
using api_development.Models;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_development.Controllers
{
    [Route("api/pagamento")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        [HttpPost]
        [Route("compras")]
        public string Post([FromServices] DataContext context, [FromBody] Pagamento model)
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
                string output = JsonConvert.SerializeObject(statusCompra);

                return output;
            }
            else
            {
                return "";
            }
        }

    }
}
