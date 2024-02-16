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
    public class JobPublicationsController : AuthController
    {
        private context db = new context();

        // GET: Publications/Details/5
        public ActionResult View(int? id)
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
            JobPublications publication = db.JobPublications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // GET: Publications/Create
        public ActionResult AddPublication()
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            IEnumerable<JobPublications> existingPublications = db.JobPublications.OrderByDescending(pub => pub.publication_id).ToList();

            PublicationVM viewModel = new PublicationVM
            {
                existingPublications = existingPublications,
                jobPublication = new JobPublications()
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

        // POST: Publications/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPublication(PublicationVM viewModel)
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }
            viewModel.existingPublications = db.JobPublications.ToList(); // Retrieve existing publications again if needed

            if (ModelState.IsValid)
            {
                // Add the received publication model to the database context
                db.JobPublications.Add(viewModel.jobPublication);

                // Save changes to the database
                db.SaveChanges();

                // Redirect to a different action after successful addition
                TempData["SuccessMessage"] = "Publication added successfully.";
                return RedirectToAction("AddPublication"); // Replace "SuccessAction" with your action name
            }

            // If ModelState is not valid, reload the view with the received PublicationVM model to show validation errors
            return View(viewModel);
        }

        // GET: Publications/Edit/5
        public ActionResult Edit(int? id)
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
            JobPublications publication = db.JobPublications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // POST: Publications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobPublications publication)
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            if (ModelState.IsValid)
            {
                // Update the received publication model in the database context
                db.Entry(publication).State = EntityState.Modified;

                // Save changes to the database
                db.SaveChanges();

                TempData["SuccessMessage"] = "Publication updated successfully.";

                // Redirect to a different action after successful update
                return RedirectToAction("AddPublication"); // Replace "SuccessAction" with your action name
            }

            return View(publication);
        }

        // POST: Publications/Delete/5
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

            JobPublications publication = db.JobPublications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }

            db.JobPublications.Remove(publication);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Publication deleted successfully.";

            return RedirectToAction("AddPublication"); // Redirect to list view after deletion
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