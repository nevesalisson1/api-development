using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_development.Data;
using api_development.Models;
using Microsoft.AspNetCore.Http;


namespace api_development.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult> Get([FromServices] DataContext context)
        {
            var products = await context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null) // Se o produto existir
            {
                return Ok(product);
            }
            else // Se o produto NÃO existir
            {
                var saida = new
                {
                    codigo = "404",
                    resposta = "O produto a ser exibido não foi achado"
                };
                return NotFound(saida);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromServices] DataContext context, [FromBody]Product model)
        {
            context.Products.Add(model);
            await context.SaveChangesAsync();
            var saida = new
            {
                codigo = "200",
                resposta = "Produto Cadastrado"
            };
            return Ok(saida);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null) // Se o produto existir
            {
                context.Products.Remove(product);
                context.SaveChanges();
                var saida = new
                {
                    codigo = "200",
                    resposta = "Produto excluído com sucesso"
                };
                return Ok(saida);
            }
            else // Se o produto NÃO existir
            {
                var saida = new
                {
                    codigo = "404",
                    resposta = "O produto a ser excluído não foi achado"
                };
                return NotFound(saida);
            }
        }
    }
}
