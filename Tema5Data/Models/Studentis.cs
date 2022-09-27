using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Tema5Data.Models
{
    public class Studentis
    {
       
        public int Id { get; set; }
      
        public string Nume { get; set; }
        
        public string Prenume { get; set; }
        
        public long? CNP { get; set; }
        
        public string Email { get; set; }

      
        [ForeignKey("Clase")]
        public int ClaseId { get; set; }
       public Clase Clase { get; set; }
        


    }
}