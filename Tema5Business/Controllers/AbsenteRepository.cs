using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema5Data.Models;

namespace Tema5Business.Controllers
{
    public class AbsenteRepository : BaseRepository
    {
        public List<Absente> Select()
        {
            var selectFrom = Business.Context.Absentes.Select(x => x);
            var query = selectFrom.Select(a => a).ToList();
            return query;


        }
        public List<Absente> SelectById(int id)
        {
            return Select().Where(x =>x.StudentisId == id).ToList();
        
        
        
        }



        public void Insert(Absente absente)
        {
            Business.Context.Absentes.Add(absente);
            Business.Context.SaveChanges();


        }
    }
}
