using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tema5.ViewModels
{
    public class Clasa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Va rog sa introduceti clasa")]
        public string Nume { get; set; }

    }
}