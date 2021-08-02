using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchTask.Models;

namespace SearchTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OutPatientTrackingSystemEntities db = new OutPatientTrackingSystemEntities();

            return View(db.Patients.ToList());
        }

        [HttpGet]
        public ActionResult PatientList1()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewPatient()
        {
            return View();
        }
    }
}
