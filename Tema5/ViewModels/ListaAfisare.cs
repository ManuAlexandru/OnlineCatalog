using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tema5.ViewModels
{
    public class ListaAfisare
    {
        public ListaAfisare()
        {
            ListaStudenti = new List<StudentDataManu>();
            Clasa = new List<SelectListItem>();


        }
        public List<StudentDataManu> ListaStudenti {get;set;}
        public List<SelectListItem> Clasa { get; set; }
        public int ClasaId { get; set; }
       

    }
}