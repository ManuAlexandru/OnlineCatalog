using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema5Data.Models;

namespace Tema5Business.Controllers
{
  public  class ClaseRepository :BaseRepository
    {

        public List<Clase> Select()
        {
            var selectFrom = Business.Context.Clases.Select(x=>x);
            var query = selectFrom.Select(a => a).ToList();
            return query;
        
        
        }


        public void Insert(Clase clase)
        {
            Business.Context.Clases.Add(clase);
            Business.Context.SaveChanges();


        }

    }
}
