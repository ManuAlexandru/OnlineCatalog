using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tema5.ViewModels
{
    public class AdaugaAbsente
    {
        //AdaugaAbsente() 
        //{
        //    ListaAbsente = new List<SelectListItem>();
        //}

        public int Id  { get; set; }
        //[Required(ErrorMessage ="Nu ati introdus data!")]
        //[RegularExpression("dd/mm/yyyy")]
        public string Data { get; set; }
        //public List<SelectListItem> ListaAbsente { get; set; }
    }
}