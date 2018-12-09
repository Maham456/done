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
    public class Hospital_requestController : Controller
    {
        public static string ideee = patientsController.idee;
        private FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3();

        // GET: Hospital_request
        public ActionResult Index()
        {
            return View(db.Hospital_request.ToList());
        }

        // GET: Hospital_request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital_request hospital_request = db.Hospital_request.Find(id);
            if (hospital_request == null)
            {
                return HttpNotFound();
            }
            return View(hospital_request);
        }

        public ActionResult Create1(int idee)
        {
            try
            {
                Hospital_request p = new Hospital_request();
                doctor_scedule doctor_shedule = db.doctor_scedule.Find(idee);
                p.doctor_id = doctor_shedule.doctor_id;
                p.Hospital_day = doctor_shedule.hospial_day;
                p.patient_name = ideee;
                p.Hospital_start_time = doctor_shedule.hospital_start_time;
                p.hospital_end_time = doctor_shedule.hospital_end_time;

                db.Hospital_request.Add(p);

                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return RedirectToAction("Index1","Clinic_request");
        }
        

        // GET: Hospital_request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospital_request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Hospital_start_time,hospital_end_time,patient_name,Hospital_day,id,doctor_id")] Hospital_request hospital_request)
        {
            if (ModelState.IsValid)
            {
                db.Hospital_request.Add(hospital_request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital_request);
        }

        // GET: Hospital_request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital_request hospital_request = db.Hospital_request.Find(id);
            if (hospital_request == null)
            {
                return HttpNotFound();
            }
            return View(hospital_request);
        }

        // POST: Hospital_request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Hospital_start_time,hospital_end_time,patient_name,Hospital_day,id,doctor_id")] Hospital_request hospital_request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital_request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital_request);
        }

        // GET: Hospital_request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital_request hospital_request = db.Hospital_request.Find(id);
            if (hospital_request == null)
            {
                return HttpNotFound();
            }
            return View(hospital_request);
        }

        // POST: Hospital_request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospital_request hospital_request = db.Hospital_request.Find(id);
            db.Hospital_request.Remove(hospital_request);
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
