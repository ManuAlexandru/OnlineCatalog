using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema5.ViewModels;
using Tema5Data.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Tema5.Controllers
{
    public class HomeController : BaseController
    {       
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            var clases = Business.ClaseRepository.Select();
            var model = new StudentVM();
            foreach (var pers in clases)
            {
                model.Clase.Add(new SelectListItem() { Text = pers.Nume, Value = pers.Id.ToString() });
            
            
            
            }
            return View("About",model);
        }

        [HttpPost]
        public ActionResult About(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                var clases = Business.ClaseRepository.Select();
                var student = new Studentis();
                
                student.Nume = studentVM.Nume;
                student.Prenume = studentVM.Prenume;
                student.CNP = studentVM.CNP;
                student.Email = studentVM.Email;
                student.ClaseId = studentVM.ClaseId; 
                Business.StudentiRepository.Insert(student);
                var listaAfisare = GetListaAfisare();
                return View("Afisare",listaAfisare);

               



            }

            else
            {
                var clases = Business.ClaseRepository.Select();
                var model = new StudentVM();
                foreach (var pers in clases)
                {
                    model.Clase.Add(new SelectListItem() { Text = pers.Nume, Value = pers.Id.ToString() });
                }

                return View("About",model);
            }
        }             

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Afisare(int clasaId=0)
        {

            //List<Studentis> studentis = Business.StudentiRepository.Select();
            // List<StudentVM> studentiDate = new List<StudentVM>();
            var listaAfisare = GetListaAfisare(clasaId);
            return View("Afisare", listaAfisare);
            
        }
        [HttpGet]
        public ActionResult IntroducereClase()
        {

            var obiect = GetListOfClasses();
            return View("IntroducereClase", obiect);
        }
        [HttpPost]
        public ActionResult IntroducereClase(Clasa clasa)
        {
            var obiect = GetListOfClasses();
            if (ModelState.IsValid)
            {
                var clase = new Clase();
                clase.Nume = clasa.Nume;
                Business.ClaseRepository.Insert(clase);
               
                return View("IntroducereClase",obiect);
            }
            else
              return View("IntroducereClase",obiect);





        }


        private ListOfClasses GetListOfClasses()
        {
            var clase = Business.ClaseRepository.Select();
            var listaClase = new List<Clasa>();
            foreach (var pers in clase)
            {
                var clasa = new Clasa();
                clasa.Id = pers.Id;
                clasa.Nume = pers.Nume;

                listaClase.Add(clasa);

            }
            var obiect = new ListOfClasses();
            obiect.ListaClase = listaClase;
            return obiect;



        }

        public ActionResult Editare(int Id)
        {
            
            var student = Business.StudentiRepository.Select(Id);
            if (student == null)
                return View("Contact");
            var studentVm = new StudentVM();
            studentVm.ClaseId = student.ClaseId;
            studentVm.CNP = student.CNP;
            studentVm.Email = student.Email;
            studentVm.Id = student.Id;
            studentVm.Nume = student.Nume;
            studentVm.Prenume = student.Prenume;

            return View("Editare",studentVm);

        }
        [HttpPost]
        public ActionResult Editare(StudentVM std)
        {

            var student = Business.StudentiRepository.Select(std.Id);
            student.ClaseId = std.ClaseId;
            student.CNP = std.CNP;
            student.Email = std.Email;
            student.Nume = std.Nume;
            student.Prenume = std.Prenume;
            Business.StudentiRepository.Update(student);
            return View();

        }
        public ActionResult Absente(int id)
        {
            var absente = Business.AbsenteRepository.SelectById(id);
            List<AdaugaAbsente> adaugaAbsente = new List<AdaugaAbsente>();
            foreach (var std in absente)
            {
                var adaugaAbsente1 = new AdaugaAbsente();
                adaugaAbsente1.Id = std.Id;
                adaugaAbsente1.Data = std.Data;
                adaugaAbsente.Add(adaugaAbsente1);            
            
            }
            var afisareAbsente = new AfisareAbsente();

            afisareAbsente.AfiasareAbs = adaugaAbsente;
            afisareAbsente.Count = absente.Count;
            return View("Absente",afisareAbsente);
        }
        [HttpPost]
        public ActionResult AdaugaAbsente(AdaugaAbsente adaugaAbsente)
        {
            var studentAbsente = new Absente();
            studentAbsente.Data = adaugaAbsente.Data;
            studentAbsente.StudentisId = adaugaAbsente.Id;
            Business.AbsenteRepository.Insert(studentAbsente);

            return View("AdaugaAbsente",adaugaAbsente);
        
        }
        public ActionResult AdaugaAbsente(int Id)
        {
            var adaugaAbsente = new AdaugaAbsente();
            adaugaAbsente.Id = Id;


            return View("AdaugaAbsente",adaugaAbsente);

        }



        private ListaAfisare GetListaAfisare(int clasaId=0)
        {
            var studentis = Business.StudentiRepository.Select();
            var clase = Business.ClaseRepository.Select();
            var claseLookUp = clase.ToLookup(x => x.Id);
            var studentDateList = new List<StudentDataManu>();
            var listaAfisare = new ListaAfisare();
            var spatiu = " ";
            if (clasaId > 0)
                studentis = studentis.Where(x => x.ClaseId == clasaId).ToList();
            foreach (var pers in studentis)
            {
                var studentDataClass = new StudentDataManu();

                studentDataClass.CNP = pers.CNP;
                studentDataClass.FullName = pers.Nume + spatiu + pers.Prenume;
                studentDataClass.Email = pers.Email;
                studentDataClass.Id = pers.Id;
                studentDataClass.StudentiId = pers.ClaseId;

                //    foreach (var item in clase) 
                //{
                //    if (item.Id == pers.ClaseId)
                //        studentDataClass.NameClass = item.Nume;
                //}
                studentDataClass.NameClass = claseLookUp[pers.ClaseId].SingleOrDefault()?.Nume;
                studentDateList.Add(studentDataClass);

            }

            foreach (var pers in clase)
            {
                listaAfisare.Clasa.Add(new SelectListItem() { Text = pers.Nume, Value = pers.Id.ToString() });



            }
            listaAfisare.ListaStudenti = studentDateList;
            return listaAfisare;




        }
        public ActionResult GetStudentiTabelBody(int clasaId = 0)
        {
            var model = GetListaAfisare(clasaId);
            return PartialView("_StudentiTabelBody", model);
        }
        //var studentiDate = new StudentData();
        //studentiDate.CNP = pers.CNP;
        //        studentiDate.Nume = pers.Nume;
        //        studentiDate.Prenume = pers.Prenume;
        //        studentiDate.Email = pers.Email;
        //        studentiDate.Id = pers.Id;
        //        studentiDate.StudentiId = pers.StudentiId;
        //        studentDate1.Add(studentiDate);



    }
}