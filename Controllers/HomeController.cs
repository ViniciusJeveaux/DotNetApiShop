using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {
            var manager = new User { Id = 1, Username = "Viniciusjeveaux", Password = "Viniciusjeveaux", Role = "manager" };
            context.Users.Add(manager);
            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Login padrão criado"
            });
        }
    }
}