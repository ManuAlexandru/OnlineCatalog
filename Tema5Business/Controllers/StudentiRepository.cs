using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema5Data.Models;

namespace Tema5Business.Controllers
{
    public class StudentiRepository :BaseRepository
    {
        public List<Studentis> Select() 
        {

            var selectFrom = Business.Context.Studentis.Select(x => x);
           // return selectFrom.ToList();
            var query = selectFrom.Select(a => a).ToList();
            // return EFToList(query);
            return query;
        
        }

        public Studentis Select(int id)
        {

            var selectFrom = Business.Context.Studentis.Select(x => x).Where(x=>x.Id==id);
            // return selectFrom.ToList();
            var query = selectFrom.Select(a => a).FirstOrDefault();
            // return EFToList(query);
            return query;

        }
        public Studentis SelectById(int id)
        {
          return  Select().FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Studentis studenti)
        {
            Business.Context.Studentis.Add(studenti);
            Business.Context.SaveChanges();
        
        
        }
        public void Update(Studentis studenti)
        {

            Business.Context.Studentis.Add(studenti);
            Business.Context.Entry(studenti).State = System.Data.Entity.EntityState.Modified;
            Business.Context.SaveChanges();

        }


    }



}
