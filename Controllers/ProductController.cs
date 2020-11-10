using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Shop.Services;

[Route("products")]
public class ProductController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Product>>> Get([FromServices]DataContext context)
    {
        
        var products = await context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
        return Ok(products);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Product>> GetByID(int id, [FromServices]DataContext context)
    {
        var product = await context.Products.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return Ok(product);
    }

    [HttpGet]
    [Route("categories/{id:int}")]
    public async Task<ActionResult<List<Product>>> GetByCategory(int id, [FromServices]DataContext context)
    {
        var products = await context.Products.Include(x => x.Category).AsNoTracking().Where(x => x.CategoryId == id).ToListAsync();
        return Ok(products);
    }

    [HttpPost]
    [Route("")]
    [Authorize]
    public async Task<ActionResult<Product>> Post(
        [FromBody]Product model,
        [FromServices]DataContext context
        )
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        try
        {
            context.Products.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }

        catch(Exception)
        {
            return BadRequest(new{message = "Não foi possivel adicionar a categoria"});
        }

    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize]
    public async Task<ActionResult<Category>> Put(
        int id, 
        [FromBody]Product model, 
        [FromServices]DataContext context
        )
    {
        
        if(!ModelState.IsValid)
            return BadRequest(ModelState);    
        
        try
        {
            context.Entry<Product>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new {menssage  ="não foi possivel atualizar o produto"});
        }    
    }

    [HttpDelete]
    [Route("{id:int}")]
    [Authorize]
    public async Task<ActionResult<Product>> Delete(int id,[FromServices]DataContext context)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product == null)
            return NotFound(new {message = "produto não encontrado"});

        try
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return Ok(new{message = "produto removido com sucesso!!"});
        }
        catch(Exception)
        {
            return BadRequest(new {message = "Não foi possivel deletar o produto"});
        } 

    }
}
