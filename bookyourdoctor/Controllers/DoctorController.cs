using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookthedoctor.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            RedirectToAction("DoctorDescription", "Doctor");
            return View();
        }
        public ActionResult DoctorWelcome()
        {
            
            return View();
    }
        public ActionResult DoctorDashboard()
        {

            return View();
        }
        public ActionResult DoctorAnnouncement()
        {

            return View();
        }
        public ActionResult DoctorReset()
        {

            return View();
        }
        public ActionResult DoctorAddSchedule()
        {

            return View();
        }
        public ActionResult DoctorViewSchedule()
        {

            return View();
        }
        public ActionResult DoctorEditSchedule()
        {

            return View();
        }
        public ActionResult DoctorClinicSchedule()
        {

            return View();
        }
        public ActionResult DoctorHospitalSchedule()
        {

            return View();
        }
        public ActionResult DoctorClinicRequests()
        {

            return View();
        }
        public ActionResult DoctorLogin()
        {

            return View();
        }
        public ActionResult DoctorHospitalRequests()
        {

            return View();
        }

        // GET: Doctor/Details/5
        public ActionResult DetailsOfDoctor()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult DoctorDescription()
        {
           
            return View();
        }
       

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
