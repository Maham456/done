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

namespace bookyourdoctor.Controllers
{
    public class hospital_viewController : Controller
    {
        public static string ideee = patientsController.idee;
        private FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3();

        // GET: hospital_view
        public ActionResult Index()
        {
            return View(db.hospital_view.ToList());
        }

        public ActionResult Create1(int idee, bookyourdoctor.Models.gmailsent model)
        {
            try
            {
                hospital_view p = new hospital_view();
                Hospital_request hospital_Request = db.Hospital_request.Find(idee);

                p.Hospital_day = hospital_Request.Hospital_day;
                p.patient_name = hospital_Request.patient_name;
                p.hospital_start_time = hospital_Request.Hospital_start_time;
                p.hospital_end_time = hospital_Request.hospital_end_time;

                db.hospital_view.Add(p);
                db.SaveChanges();

                MailMessage mm = new MailMessage("maham.asif456@gmail.com", ideee);//model.To ki jagah patient i

                mm.Subject = "APPOINTMENT STATUS";
                model.Subject = mm.Subject;
                mm.Body = p.patient_name + "" + "Your request has been rejected" + ". " + "You need to come to the hospital at time" + "" + model.startTime + " " + "to" + model.endTime + "" + "on" + "" + p.Hospital_day;
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

            return RedirectToAction("Index2", "Clinic_request");
        }
        public ActionResult Create2(int idee, bookyourdoctor.Models.gmailsent model)
        {

            hospital_view p = new hospital_view();
            Hospital_request hospital_Request = db.Hospital_request.Find(idee);

            p.Hospital_day = hospital_Request.Hospital_day;
            p.patient_name = hospital_Request.patient_name;
            p.hospital_start_time = hospital_Request.Hospital_start_time;
            p.hospital_end_time = hospital_Request.hospital_end_time;

            db.hospital_view.Add(p);
            db.SaveChanges();
            MailMessage mm = new MailMessage("maham.asif456@gmail.com", ideee);//model.To ki jagah patient i

            mm.Subject = "APPOINTMENT STATUS";
            model.Subject = mm.Subject;
            mm.Body = p.patient_name + "" + "Your request has been rejected" + ". " + "You need to come to the hospital at time" + "" + model.startTime + " " + "to" + model.endTime + "" + "on" + "" + p.Hospital_day;
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

            return RedirectToAction("Index2", "Clinic_request");
            //return RedirectToAction("Index1");
        }

        public ActionResult Index1()
        {
            return View();
        }

        // GET: hospital_view/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_view hospital_view = db.hospital_view.Find(id);
            if (hospital_view == null)
            {
                return HttpNotFound();
            }
            return View(hospital_view);
        }

        // GET: hospital_view/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hospital_view/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hospital_end_time,hospital_start_time,patient_name,Hospital_day,id")] hospital_view hospital_view)
        {
            if (ModelState.IsValid)
            {
                db.hospital_view.Add(hospital_view);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital_view);
        }

        // GET: hospital_view/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_view hospital_view = db.hospital_view.Find(id);
            if (hospital_view == null)
            {
                return HttpNotFound();
            }
            return View(hospital_view);
        }

        // POST: hospital_view/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hospital_end_time,hospital_start_time,patient_name,Hospital_day,id")] hospital_view hospital_view)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital_view).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital_view);
        }

        // GET: hospital_view/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_view hospital_view = db.hospital_view.Find(id);
            if (hospital_view == null)
            {
                return HttpNotFound();
            }
            return View(hospital_view);
        }

        // POST: hospital_view/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hospital_view hospital_view = db.hospital_view.Find(id);
            db.hospital_view.Remove(hospital_view);
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
