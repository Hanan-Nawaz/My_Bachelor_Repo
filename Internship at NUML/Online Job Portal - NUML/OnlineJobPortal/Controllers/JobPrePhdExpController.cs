using OnlineJobPortal.DbContect;
using OnlineJobPortal.Models;
using OnlineJobPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobPortal.Controllers
{
    public class JobPrePhdExpController : AuthController
    {
        private context db = new context();

        // GET: JobPostPhdExp
        public ActionResult ViewPrePhdExp(int? id)
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPrePhdExp jobPostPhdExp = db.prePhdExps.Find(id);
            if (jobPostPhdExp == null)
            {
                return HttpNotFound();
            }
            return View(jobPostPhdExp);
        }

        // GET: JobPostPhdExp/Create
        public ActionResult AddPrePhdExp()
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            IEnumerable<JobPrePhdExp> existingPublications = db.prePhdExps.OrderByDescending(pub => pub.id).ToList();

            PrePhdVM viewModel = new PrePhdVM
            {
                existingPreExp = existingPublications,
                jobPrePhdExp = new JobPrePhdExp()
            };



            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
                ViewBag.alertMessage = "";
            }
            else
            {
                ViewBag.SuccessMessage = "";
                ViewBag.alertMessage = "";
            }

            return View(viewModel);
        }

        // POST: JobPostPhdExp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPrePhdExp(PrePhdVM viewModel)
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            viewModel.existingPreExp = db.prePhdExps.ToList(); // Retrieve existing publications again if needed

            if (ModelState.IsValid)
            {
                // Add the received publication model to the database context
                db.prePhdExps.Add(viewModel.jobPrePhdExp);

                // Save changes to the database
                db.SaveChanges();

                // Redirect to a different action after successful addition
                TempData["SuccessMessage"] = "Pre Phd Experience added successfully.";
                return RedirectToAction("AddPrePhdExp"); // Replace "SuccessAction" with your action name
            }

            // If ModelState is not valid, reload the view with the received PublicationVM model to show validation errors
            return View(viewModel);
        }

        // GET: JobPostPhdExp/Edit/5
        public ActionResult EditPrePhdExp(int? id)
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            JobPrePhdExp jobPostPhdExp = db.prePhdExps.Find(id);
            if (jobPostPhdExp == null)
            {
                return HttpNotFound();
            }
            return View(jobPostPhdExp);
        }

        // POST: JobPostPhdExp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPrePhdExp(JobPrePhdExp jobPrePhdExp)
        {

            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            {
                db.Entry(jobPrePhdExp).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Pre PhD Experience updated successfully.";
                return RedirectToAction("AddPrePhdExp");
            }

            return View(jobPrePhdExp);
        }

        // POST: JobPostPhdExp/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            JobPrePhdExp jobPostPhdExp = db.prePhdExps.Find(id);
            if (jobPostPhdExp == null)
            {
                return HttpNotFound();
            }
            db.prePhdExps.Remove(jobPostPhdExp);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Pre PhD Experience deleted successfully.";
            return RedirectToAction("AddPrePhdExp");
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