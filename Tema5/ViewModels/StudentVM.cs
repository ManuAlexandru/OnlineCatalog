using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tema5.ViewModels
{
    public class StudentVM
    {
        public StudentVM()
        {
            Clase = new List<SelectListItem>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Va rog sa introduceti numele")]
        public string Nume { get; set; }
        [Required(ErrorMessage = "Va rog sa introduceti prenumele")]
        public string Prenume { get; set; }
        [Required(ErrorMessage = "Va rog sa introduceti C.N.P-ul")]
        [RegularExpression("^[1-9]\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])(0[1-9]|[1-4]\\d|5[0-2]|99)(00[1-9]|0[1-9]\\d|[1-9]\\d\\d)\\d$", ErrorMessage = "Nu ati introdus C.N.P-ul corect!")]
        public long? CNP { get; set; }
        [Required(ErrorMessage = "Va rog sa introduceti email-ul")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Nu ati introdus corect adresa de email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Va rog sa introduceti clasa")]
        public int ClaseId { get; set; }
        [Required(ErrorMessage = "Va rog sa alegeti clasa cu care veti participa!")]
        public List<SelectListItem> Clase { get; set; }


    }
}