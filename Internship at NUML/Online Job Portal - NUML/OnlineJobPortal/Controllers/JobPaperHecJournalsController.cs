using OnlineJobPortal.DbContect;
using OnlineJobPortal.Models;
using OnlineJobPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobPortal.Controllers
{
    public class JobPaperHecJournalsController : AuthController
    {
        private context db = new context();

        // GET: JobPaperHecJournals
        public ActionResult AddHecJournal()
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            IEnumerable<JobPaperhecJournals> existingPapers = db.jobPaperhecJournals.OrderByDescending(paper => paper.id).ToList();

            HecJournalsVM viewModel = new HecJournalsVM
            {
                existingPapers = existingPapers,
                jobPaperhecJournals = new JobPaperhecJournals()
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

        // POST: JobPaperHecJournals/AddHecJournalsData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHecJournal(HecJournalsVM viewModel)
        {
            ActionResult validationResult = ValidateJobToken();

            if (validationResult != null)
            {
                return validationResult;
            }

            viewModel.existingPapers = db.jobPaperhecJournals.ToList(); 

            if (ModelState.IsValid)
            {
                db.jobPaperhecJournals.Add(viewModel.jobPaperhecJournals);

                db.SaveChanges();

                TempData["SuccessMessage"] = "HEC Journals Data added successfully.";
                return RedirectToAction("AddHecJournal"); 
            }

            return View("AddHecJournal");
        }

        public ActionResult ViewHecJournal(int? id)
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
            JobPaperhecJournals jobPaperHecJournals = db.jobPaperhecJournals.Find(id);
            if (jobPaperHecJournals == null)
            {
                return HttpNotFound();
            }
            return View(jobPaperHecJournals);
        }

        // GET: JobPaperHecJournals/EditHecJournalsData/5
        public ActionResult EditHecJournal(int? id)
        {
            ActionResult validationResult = ValidateJobToken();

            if (validationResult != null)
            {
                return validationResult;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPaperhecJournals jobPaperHecJournals = db.jobPaperhecJournals.Find(id);
            if (jobPaperHecJournals == null)
            {
                return HttpNotFound();
            }
            return View(jobPaperHecJournals);
        }

        // POST: JobPaperHecJournals/EditHecJournalsData/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHecJournal(JobPaperhecJournals jobPaperHecJournals)
        {
            ActionResult validationResult = ValidateJobToken();

            // Check if validation failed and return the result if it did
            if (validationResult != null)
            {
                return validationResult;
            }

            if (ModelState.IsValid)
            {
                db.Entry(jobPaperHecJournals).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "HEC Journals Data updated successfully.";
                return RedirectToAction("AddHecJournal");
            }
            return RedirectToAction("AddHecJournal");
        }

        // POST: JobPaperHecJournals/DeleteConfirmed/5
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

            JobPaperhecJournals jobPaperHecJournals = db.jobPaperhecJournals.Find(id);
            if (jobPaperHecJournals == null)
            {
                return HttpNotFound();
            }
            db.jobPaperhecJournals.Remove(jobPaperHecJournals);
            db.SaveChanges();
            TempData["SuccessMessage"] = "HEC Journals Data deleted successfully.";
            return RedirectToAction("AddHecJournal");
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