using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tema5Data.Models
{
   
   
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext()
            : base("Name=dbContext")
        {
        }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Studentis> Studentis { get; set; }
        public DbSet<Absente> Absentes { get; set; }
             
      
    }
}