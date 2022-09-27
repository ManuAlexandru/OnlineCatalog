using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5Business.Controllers
{
  public  class BaseRepository
    {
        private Business _business;
        public Business Business 
        {
             get { return _business ?? (_business = new Business()); }
            //get { if (_business != null) return _business;
            //    else
            //        return new Business();    
            //    }


        }

        protected List<T> EFToList<T>(IQueryable<T> query) where T : class { return query.AsNoTracking().ToList(); }

    }
}
