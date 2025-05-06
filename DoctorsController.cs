using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication8.Controllers;
using WebApplication8.Models;


namespace WebApplication8.Controllers
{
    public class DoctorsController : Controller
    {
        private static List<Doctor> doctors = new List<Doctor>();
        private static int nextId = 1;

        public ActionResult Index()
        {
            ViewBag.Hospitals = HospitalsController.GetAll();
            return View(doctors);
        }

        public ActionResult Details(int id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            ViewBag.Hospital = HospitalsController.GetAll().FirstOrDefault(h => h.Id == doctor.HospitalId);
            ViewBag.AllPatients = PatientsController.GetAll();
            return View(doctor);
        }

        public ActionResult Create()
        {
            ViewBag.Hospitals = new SelectList(HospitalsController.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            doctor.Id = nextId++;
            doctors.Add(doctor);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            ViewBag.Hospitals = new SelectList(HospitalsController.GetAll(), "Id", "Name", doctor.HospitalId);
            return View(doctor);
        }

        [HttpPost]
        public ActionResult Edit(Doctor updated)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == updated.Id);
            doctor.Name = updated.Name;
            doctor.Specialization = updated.Specialization;
            doctor.HospitalId = updated.HospitalId;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            doctors.Remove(doctor);
            return RedirectToAction("Index");
        }

        public ActionResult AddPatient(int id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            ViewBag.Doctor = doctor;
            ViewBag.Patients = new SelectList(PatientsController.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient(int doctorId, int patientId)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == doctorId);
            if (!doctor.PatientIds.Contains(patientId))
                doctor.PatientIds.Add(patientId);

            return RedirectToAction("Details", new { id = doctorId });
        }

        public static List<Doctor> GetAll()
        {
            return doctors;
        }
    }
}
