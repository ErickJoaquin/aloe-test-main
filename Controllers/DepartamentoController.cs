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
    public class DepartamentoController : ControllerBase  
    {  
        private MyDBContext myDbContext;  
  
        public DepartamentoController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
  
        [HttpGet]  
        public IList<Departamento> Get()  
        {  
            return (this.myDbContext.Departamentos.ToList());  
        }  

        [HttpPost]
        public async Task<ActionResult<Departamento>> Post(Departamento departamento)
        {
            myDbContext.Departamentos.Add(departamento);
            await myDbContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Get), new { id = departamento.Id }, departamento);
        }

    }  
}   