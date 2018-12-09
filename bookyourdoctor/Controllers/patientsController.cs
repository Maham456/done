using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookyourdoctor;

namespace bookyourdoctor.Controllers
{
    public class patientsController : Controller
    {
        public static string idee;
        private FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3();

        // GET: patients
        public ActionResult Index()
        {
            return View(db.patients.ToList());
        }

        // GET: patients/Details/5
        public ActionResult Details(string ide)
        {
            idee = ide;
            if (ide == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(ide);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(patient p)
        {
            using (FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3())
            {
                var usr = db.patients.SingleOrDefault(u => u.email == p.email);
                
                if (usr != null)
                {
                    if (usr.password.Trim().ToString() == p.password.Trim().ToString())
                    {
                        Session["email"] = usr.email.ToString();
                        idee = p.email;
                        return RedirectToAction("PatientWelcome", "patients", new { ide = usr.email.ToString() });

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is wrong");
                }
            }
            return View(p);

        }

        public ActionResult PatientWelcome(string ide)
        {
            patient dp = new patient();
            dp.email = ide.Trim();
            Session["email"] = ide.Trim();
            return View(dp);
        }



        public ActionResult SelectDoctor()
        {
            return View();
        }

        public ActionResult ViewDoctorDetails()
        {
            return View();
        }
        public ActionResult TakeAppoitment()
        {
            return View();
        }

        public ActionResult CardiologistsDetails()
        {
            return View();
        }

        public ActionResult ChildSpecialistDetails()
        {
            return View();
        }

        public ActionResult DermatologistDetails()
        {
            return View();
        }
        public ActionResult GynecologistDetails()
        {
            return View();
        }

        public ActionResult DentistDetails()
        {
            return View();
        }
        public ActionResult PsychologistDetails()
        {
            return View();
        }

        



       

        public ActionResult GetHospitalAppoitment()
        {
            return View();
        }



        // GET: patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,email,contact_number,password,Confirm_password")] patient patient)
        {
            
            if (ModelState.IsValid)
            {
                db.patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("PatientWelcome", "patients", new { ide = patient.email.ToString() });
            }

            return View(patient);
        }

        // GET: patients/Edit/5
        public ActionResult Edit(string ide)
        {
            if (ide == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(ide);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name,email,contact_number,password,Confirm_password")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: patients/Delete/5
        public ActionResult Delete(string ide)
        {
            if (ide == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(ide);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string ide)
        {
            patient patient = db.patients.Find(ide);
            db.patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
