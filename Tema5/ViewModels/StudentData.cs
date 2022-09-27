using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tema5.ViewModels
{
    public class StudentData
    {
        public int Id { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        public long? CNP { get; set; }

        public string Email { get; set; }



        public int StudentiId { get; set; }

        public string FullName
        {
            get { return $"{Nume} {Prenume}"; }                
        }


    }
}