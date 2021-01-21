using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace test_aloe.Models  
{  
    public class Departamento  
    {  
        public int Id { get; set;}  
        public string Nombre { get; set;}
        public string Codigo { get; set;}
        public List<Usuario> Usuarios { get; set; }
    }  
}  