using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineJobPortal.DbContect;
using OnlineJobPortal.Models;
using OnlineJobPortal.ViewModel;

namespace OnlineJobPortal.Controllers
{
    public class JobAdsController : Controller
    {
        private context db = new context();

        // GET: JobAds/Details/5
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAds jobAds = db.JobsAds.Find(id);
            if (jobAds == null)
            {
                return HttpNotFound();
            }
            return View(jobAds);
        }

        // GET: JobAds/Create
        public ActionResult AddJob()
        {
            IEnumerable<JobAds> existingAds = db.JobsAds.OrderByDescending(job => job.job_id).ToList();

            JobVM viewModel = new JobVM
            {
                existingAds = existingAds,
                jobAds = new JobAds()
                {
                    job_advertisment = "just to avoid error"
                }
            };



            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SucessMessage = TempData["SuccessMessage"].ToString();
                ViewBag.alertMessage = "";
            }
            else
            {
                ViewBag.SucessMessage = "";
                ViewBag.alertMessage = "";

            }

            return View(viewModel);
        }


        // POST: JobAds/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddJob(JobVM viewModel, HttpPostedFileBase file)
        {
            viewModel.existingAds = db.JobsAds.ToList(); // Retrieve existing job ads again if needed
            viewModel.jobAds.job_advertisment = " ";

            if(viewModel.jobAds.job_type == "regular" && viewModel.jobAds.is_job_processing_fee == 0)
            {
                TempData["SuccessMessage"] = "Error! Please enter processing fee.";
                return View(viewModel);
            }
            else
            {
                if (file != null)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Advertisements"), fileName);
                        file.SaveAs(path);

                        // Store the file path in the database
                        viewModel.jobAds.job_advertisment = "/Advertisements/" + fileName; // Save relative path
                    }

                    // Add the received jobAds model to the database context
                    db.JobsAds.Add(viewModel.jobAds);

                    // Save changes to the database
                    db.SaveChanges();

                    // Redirect to a different action after successful addition
                    TempData["SuccessMessage"] = "Job added successfully.";
                    return RedirectToAction("AddJob"); // Replace "SuccessAction" with your action name
                }
            }

            

            // If ModelState is not valid, reload the view with the received JobVM model to show validation errors
            return View(viewModel);
        }


        // GET: JobAds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAds jobAds = db.JobsAds.Find(id);
            if (jobAds == null)
            {
                return HttpNotFound();
            }
            return View(jobAds);
        }

        // POST: JobAds/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string ad, JobAds jobAds, HttpPostedFileBase file)
        {

            try
            {
                // Your code where you save changes to the database using Entity Framework
                jobAds.job_id = id;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Advertisements"), fileName);
                    file.SaveAs(path);

                    // Store the file path in the database
                    jobAds.job_advertisment = "/Advertisements/" + fileName; // Save relative path
                }
                else
                {
                    jobAds.job_advertisment = ad;
                }

                // Add the received jobAds model to the database context
                db.Entry(jobAds).State = EntityState.Modified;

                // Save changes to the database

                db.SaveChanges();


                TempData["SuccessMessage"] = "Job updated successfully.";

                // Redirect to a different action after successful addition
                return RedirectToAction("AddJob"); // Replace "SuccessAction" with your action name

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine(
                            $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        // Log or handle the validation error messages as needed
                    }
                }
                // Handle the exception or throw it again if needed
                // throw;
            }


            return View(jobAds);
        }


        // POST: JobAds/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobAds job = db.JobsAds.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }

            db.JobsAds.Remove(job);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Job deleted successfully.";

            return RedirectToAction("AddJob"); // Redirect to list view after deletion
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
