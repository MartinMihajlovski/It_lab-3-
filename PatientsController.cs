using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication8.Models;


namespace WebApplication8.Controllers
{
    public class PatientsController : Controller
    {
        private static List<Patient> patients = new List<Patient>();
        private static int nextId = 1;

        public ActionResult Index()
        {
            return View(patients);
        }

        public ActionResult Details(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);
            return View(patient);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            patient.Id = nextId++;
            patients.Add(patient);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patient updated)
        {
            var patient = patients.FirstOrDefault(p => p.Id == updated.Id);
            patient.Name = updated.Name;
            patient.PatientCode = updated.PatientCode;
            patient.Gender = updated.Gender;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);
            patients.Remove(patient);
            return RedirectToAction("Index");
        }

        // За други контролери (на пр. Doctor) да можат да добијат листа од сите пациенти
        public static List<Patient> GetAll()
        {
            return patients;
        }
    }
}
