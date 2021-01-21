using MaestroDetalle.DBContexts;  
using test_aloe.Models;  
using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Mvc;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using System.Data.Entity;  
using System.Data.Entity.Infrastructure;  

  
namespace test_aloe.Controllers  
{  
    [Route("api/[controller]")]  
    [ApiController]  
    public class UsuarioController : ControllerBase  
    {  
        private MyDBContext myDbContext;  
  
        public UsuarioController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
  
        [HttpGet]  
        public IList<Usuario> Get()  
        {  
            return (this.myDbContext.Usuarios.ToList());  
        }  

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            myDbContext.Usuarios.Add(usuario);
            await myDbContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

    }  
}   