using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_development.Data;
using api_development.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_development.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> DeleteById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product;
        }
    }
}
