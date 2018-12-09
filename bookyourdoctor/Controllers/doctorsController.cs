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
    public class doctorsController : Controller
    {
        public FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3();

        // GET: doctors
        public ActionResult Index()
        {
            return View(db.doctors.ToList());
        }

        // GET: doctors/Details/5
        public ActionResult Details(string ide)
        {
            if (ide == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(ide);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }
        public ActionResult viewDetails(string ide)
        {
            if (ide == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(ide);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(doctor p)
        {
            using (FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3())
            {
                var usr = db.doctors.SingleOrDefault(u => u.doctor_id == p.doctor_id);
                if (usr != null)
                {
                    if (usr.password.ToString() == p.password.ToString())
                    {
                        Session["doctor_id"] = usr.doctor_id.ToString();
                        return RedirectToAction("DoctorWelcome1","doctor_scedule", new { ide = usr.doctor_id.ToString()});

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is wrong");
                }
            }
            return View(p);

        }

       

        // GET: doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "doctor_id,name,date_of_birth,adress,phone,MBBS_Code,email,password,confirm_password,clinic_name,hospital_address,hospital_name,clinic_address,city,specialization,practising_years")] doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }


        public ActionResult ViewShedule(string ide)
        {
            if (ide == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            doctor doctor = db.doctors.Find(ide);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }
        
        






        // GET: doctors/Edit/5
        public ActionResult Edit(string ide)
        {
            if (ide == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(ide);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "doctor_id,name,date_of_birth,adress,phone,MBBS_Code,email,password,confirm_password,clinic_name,hospital_address,hospital_name,clinic_address,city,specialization,practising_years")] doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: doctors/Delete/5
        public ActionResult Delete(string ide)
        {
            if (ide == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(ide);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string ide)
        {
            doctor doctor = db.doctors.Find(ide);
            db.doctors.Remove(doctor);
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
