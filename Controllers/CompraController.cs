using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_development.Data;
using api_development.Models;
using System.Linq;

namespace api_development.Controllers
{
    [Route("api")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        [HttpPost]
        [Route("compras")]
        public async Task<ActionResult> Post([FromServices] DataContext context, [FromBody] Compra model)
        {
            if (model.Cartao.CreditCard_Evaluation() == 1) // Se o cartão é válido.
            {
                var product = context.Products.Where(x => x.Id == model.Produto_id).FirstOrDefault();
                if (product != null) // Se o produto existir
                {
                    if (model.Qtde_comprada <= product.Qtde_estoque) // Se a quantidade de compras é menor que a quantidade em estoque 
                    {

                        var produto = context.Products.SingleOrDefault(x => x.Id == model.Produto_id);
                        context.Compra.Add(model);
                        produto.Data_ultima_venda = System.DateTime.Now; //Seta a data ultima venda
                        produto.Valor_ultima_venda = model.Qtde_comprada * produto.Valor_unitario; // Seta "valor_ultima_venda" 
                        produto.Qtde_estoque -= model.Qtde_comprada; // Diminui do banco a quantidade de estoque subtraindo a quantidade comprada
                        await context.SaveChangesAsync();

                        var saida = new
                        {
                            codigo = "200",
                            resposta = "Venda realizada com sucesso"
                        };
                        return Ok(saida);

                    }
                    else // Se a quantidade de compras é MAIOR que a quantidade em estoque 
                    {
                        var saida = new
                        {
                            codigo = "400",
                            resposta = "A quantidade a ser comprada é maior que a quantidade em estoque"
                        };
                        return BadRequest(saida);
                    }
                }
                else // Se o produto NÃO existir
                {
                    var saida = new
                    {
                        codigo = "404",
                        resposta = "O produto a ser comprado não foi achado"
                    };
                    return NotFound(saida);
                }
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
