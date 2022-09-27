using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5Data.Models
{
   public class Absente
    {
        
        public int StudentisId { get; set; }
        public int Id { get; set; }
        public string Data { get; set; }
        
    }
}
