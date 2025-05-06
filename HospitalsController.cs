using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication8.Models;


namespace WebApplication8.Controllers
{
    public class HospitalsController : Controller
    {
        private static List<Hospital> hospitals = new List<Hospital>();
        private static int nextId = 1;

        public ActionResult Index()
        {
            return View(hospitals);
        }

        public ActionResult Details(int id)
        {
            var hospital = hospitals.FirstOrDefault(h => h.Id == id);
            return View(hospital);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hospital hospital)
        {
            hospital.Id = nextId++;
            hospitals.Add(hospital);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var hospital = hospitals.FirstOrDefault(h => h.Id == id);
            return View(hospital);
        }

        [HttpPost]
        public ActionResult Edit(Hospital updated)
        {
            var hospital = hospitals.FirstOrDefault(h => h.Id == updated.Id);
            hospital.Name = updated.Name;
            hospital.Address = updated.Address;
            hospital.ImageUrl = updated.ImageUrl;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var hospital = hospitals.FirstOrDefault(h => h.Id == id);
            return View(hospital);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var hospital = hospitals.FirstOrDefault(h => h.Id == id);
            hospitals.Remove(hospital);
            return RedirectToAction("Index");
        }

        public static List<Hospital> GetAll()
        {
            return hospitals;
        }
    }
}
