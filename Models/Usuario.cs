using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace test_aloe.Models  
{  
    public class Usuario  
    {  
        public int Id { get; set;}  
        public string Nombre { get; set;}
        public string Apellido { get; set;}
        public string Genero { get; set;}    
        public string Cedula { get; set;}
        public DateTime FechaNacimiento { get; set;}
        public int DepartamentoId { get; set;}
        public string cargo { get; set;}
        public string Supervisor { get; set;}
        public Departamento Departments { get; set; }
    }  
}  