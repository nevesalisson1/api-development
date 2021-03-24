using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_development.Data;
using api_development.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_development.Controllers
{
    [Route("api")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        [HttpPost]
        [Route("compras")]
        public async Task<Compra> Post([FromServices] DataContext context, [FromBody] Compra model)
        {
            context.Compra.Add(model);
            await context.SaveChangesAsync();
            return model;  
        }

    }
}
