using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using bookyourdoctor;
using bookyourdoctor.Models;

namespace bookyourdoctor.Controllers
{
    public class Clinic_requestController : Controller
    {
        public static string ideee = patientsController.idee;
        private FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3();

        // GET: Clinic_request
        public ActionResult Index()
        {
            return View(db.Clinic_request.ToList());
        }

        // GET: Clinic_request/Create
        public ActionResult Create1(int idee, bookyourdoctor.Models.gmailsent model)
        {
            
            Clinic_request p = new Clinic_request();
            doctor_scedule doctor_shedule = db.doctor_scedule.Find(idee);
            p.doctor_id = doctor_shedule.doctor_id;
            p.clinic_day = doctor_shedule.Clinic_day;
            p.patient_name = ideee;
            p.clinic_start_time = doctor_shedule.clinic_start_time;
            p.clinic_end_time = doctor_shedule.clinic_end_time;
            db.Clinic_request.Add(p);
            db.SaveChanges();
            MailMessage mm = new MailMessage("maham.asif456@gmail.com",ideee);//model.To ki jagah patient i

            mm.Subject = "APPOINTMENT STATUS";
            model.Subject = mm.Subject;
            mm.Body = "Your request has been accepted" + ". " + "You need to come to the hospital at time" + "" + model.startTime + " " + "to" + model.endTime;
            model.Body = mm.Body;

            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            NetworkCredential nc = new NetworkCredential("maham.asif456@gmail.com", "maham180598");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail has been sent successfully";
            return RedirectToAction("Index1", "Clinic_request");
        }
        public ActionResult Create2(int idee)
        {

            Clinic_request p = new Clinic_request();
            doctor_scedule doctor_shedule = db.doctor_scedule.Find(idee);
            p.doctor_id = doctor_shedule.doctor_id;
            p.clinic_day = doctor_shedule.Clinic_day;
            p.patient_name = ideee;
            p.clinic_start_time = doctor_shedule.clinic_start_time;
            p.clinic_end_time = doctor_shedule.clinic_end_time;
            db.Clinic_request.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index1","Clinic_request");
        }

        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }




        // GET: Clinic_request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic_request clinic_request = db.Clinic_request.Find(id);
            if (clinic_request == null)
            {
                return HttpNotFound();
            }
            return View(clinic_request);
        }

        // GET: Clinic_request/Create
        public ActionResult Create()
        {
            return View();

           
        }

        // POST: Clinic_request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clinic_start_time,clinic_end_time,patient_name,id,clinic_day,doctor_id")] Clinic_request clinic_request)
        {
            if (ModelState.IsValid)
            {
                db.Clinic_request.Add(clinic_request);
                try
                {
                    db.SaveChanges();
                }
                catch( Exception e)
                {
                    Console.WriteLine(e);

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clinic_request);
        }

        // GET: Clinic_request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic_request clinic_request = db.Clinic_request.Find(id);
            if (clinic_request == null)
            {
                return HttpNotFound();
            }
            return View(clinic_request);
        }

        // POST: Clinic_request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clinic_start_time,clinic_end_time,patient_name,id,clinic_day,doctor_id")] Clinic_request clinic_request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinic_request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinic_request);
        }

        // GET: Clinic_request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic_request clinic_request = db.Clinic_request.Find(id);
            if (clinic_request == null)
            {
                return HttpNotFound();
            }
            return View(clinic_request);
        }

        // POST: Clinic_request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clinic_request clinic_request = db.Clinic_request.Find(id);
            db.Clinic_request.Remove(clinic_request);
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
