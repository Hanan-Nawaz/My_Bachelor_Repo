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
    public class JobPostPhdExpController : AuthController
    {
        private context db = new context();

        // GET: JobPostPhdExp
        public ActionResult ViewPostPhdExp(int? id)
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
            JobPostPhdExp jobPostPhdExp = db.postPhdExps.Find(id);
            if (jobPostPhdExp == null)
            {
                return HttpNotFound();
            }
            return View(jobPostPhdExp);
        }

        // GET: JobPostPhdExp/Create
        public ActionResult AddPostPhdExp()
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            IEnumerable<JobPostPhdExp> existingPublications = db.postPhdExps.OrderByDescending(pub => pub.id).ToList();

            PostPhdVM viewModel = new PostPhdVM
            {
                existingPostExp = existingPublications,
                jobPostPhdExp = new JobPostPhdExp()
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
        public ActionResult AddPostPhdExp(PostPhdVM viewModel)
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            viewModel.existingPostExp = db.postPhdExps.ToList(); // Retrieve existing publications again if needed

            if (ModelState.IsValid)
            {
                // Add the received publication model to the database context
                db.postPhdExps.Add(viewModel.jobPostPhdExp);

                // Save changes to the database
                db.SaveChanges();

                // Redirect to a different action after successful addition
                TempData["SuccessMessage"] = "Post Phd Experience added successfully.";
                return RedirectToAction("AddPostPhdExp"); // Replace "SuccessAction" with your action name
            }

            // If ModelState is not valid, reload the view with the received PublicationVM model to show validation errors
            return View(viewModel);
        }

        // GET: JobPostPhdExp/Edit/5
        public ActionResult EditPostPhdExp(int? id)
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
            JobPostPhdExp jobPostPhdExp = db.postPhdExps.Find(id);
            if (jobPostPhdExp == null)
            {
                return HttpNotFound();
            }
            return View(jobPostPhdExp);
        }

        // POST: JobPostPhdExp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPostPhdExp(JobPostPhdExp jobPostPhdExp)
        {

            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            {
                db.Entry(jobPostPhdExp).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Post PhD Experience updated successfully.";
                return RedirectToAction("AddPostPhdExp");
            }
            
            return View(jobPostPhdExp);
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

            JobPostPhdExp jobPostPhdExp = db.postPhdExps.Find(id);
            if (jobPostPhdExp == null)
            {
                return HttpNotFound();
            }
            db.postPhdExps.Remove(jobPostPhdExp);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Post PhD Experience deleted successfully.";
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