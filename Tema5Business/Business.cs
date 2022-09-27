using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema5Data.Models;
using Tema5Business.Controllers;

namespace Tema5Business
{
   public class Business
    {
        private ApplicationDbContext _context;
        
        public ApplicationDbContext Context 
        {
            get { return _context ?? (_context = new ApplicationDbContext()); }
            
        
        }

        private StudentiRepository _studentiRepository;

        public StudentiRepository StudentiRepository
        {
            get { return _studentiRepository ?? (_studentiRepository = new StudentiRepository()); }

        }

        private ClaseRepository _claseRepository;

        public ClaseRepository ClaseRepository
        {
            get { return _claseRepository ?? (_claseRepository = new ClaseRepository()); }

        }

        private AbsenteRepository _absenteRepository;

        public AbsenteRepository AbsenteRepository
        {
            get { return _absenteRepository ?? (_absenteRepository = new AbsenteRepository()); }

        }




    }
}
