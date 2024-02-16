using OnlineJobPortal.DbContect;
using OnlineJobPortal.Models;
using OnlineJobPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobPortal.Controllers
{
    public class AuthController : Controller
    {
        private context db = new context();

        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(JobGuestUsers jobGuestUsers)
        {
            bool isUnique = db.userinfo.All(u => u.CNIC != jobGuestUsers.CNIC && u.CellPhone != jobGuestUsers.CellPhone && u.Email != jobGuestUsers.Email);

            if(isUnique)
            {
                db.userinfo.Add(jobGuestUsers);
                int affectedRows = db.SaveChanges();

                if (affectedRows > 0)
                {
                    string userToken = Guid.NewGuid().ToString();

                    GuestUserToken guestUserToken = new GuestUserToken();

                    guestUserToken.AuthToken = userToken + jobGuestUsers.GuestID;
                    guestUserToken.IssuedOn = DateTime.Now;
                    guestUserToken.UserID = jobGuestUsers.GuestID.ToString();
                    guestUserToken.ExpiresOn = DateTime.Now.AddMinutes(30);

                    db.userToken.Add(guestUserToken);
                    int rowsAffected = db.SaveChanges();

                    if(rowsAffected > 0)
                    {
                        TempData["SuccessMessage"] = "Signed up successfully.";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        JobGuestUsers userToRemove = db.userinfo.Find(jobGuestUsers.GuestID);
                        db.userinfo.Remove(userToRemove);
                        db.SaveChanges();
                        TempData["SuccessMessage"] = "Error! try Again.";

                        return RedirectToAction("SignUp");
                    }
                }
                else
                {
                    TempData["SuccessMessage"] = "Error! try Again.";
                    return RedirectToAction("SignUp");
                }
            }
            else
            {
                TempData["SuccessMessage"] = "User already exist. Please Login";
                return RedirectToAction("SignUp");
            }



        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(JobGuestUsers jobGuestUsers)
        {
            bool isUnique = db.userinfo.Any(u => u.Email == jobGuestUsers.Email && u.Password == jobGuestUsers.Password);

            if (isUnique)
            {
                JobGuestUsers loggedInUser = db.userinfo.FirstOrDefault(u => u.Email == jobGuestUsers.Email && u.Password == jobGuestUsers.Password);
                GuestUserToken guestUserToken = db.userToken.FirstOrDefault(u => u.UserID == jobGuestUsers.GuestID.ToString());

                HttpCookie userInfoCookie = new HttpCookie("UserInfo");

                if(guestUserToken != null)
                {
                    db.userToken.Remove(guestUserToken);
                    db.SaveChanges();
                }

                string userToken = Guid.NewGuid().ToString();

                GuestUserToken guestUserTokens = new GuestUserToken();

                guestUserTokens.AuthToken = userToken + loggedInUser.GuestID;
                guestUserTokens.IssuedOn = DateTime.Now;
                guestUserTokens.UserID = loggedInUser.GuestID.ToString();
                guestUserTokens.ExpiresOn = DateTime.Now.AddMinutes(30);

                db.userToken.Add(guestUserTokens);
                int rowsAffected = db.SaveChanges();


                // Add data to the cookie
                userInfoCookie["UserID"] = loggedInUser.GuestID.ToString();
                userInfoCookie["Token"] = guestUserTokens.TokenID.ToString();
                userInfoCookie["ExpiresOn"] = guestUserTokens.ExpiresOn.ToString();

                // Set the expiration time for the cookie
                userInfoCookie.Expires = DateTime.Now.AddHours(3); // Example: Expires in 3 hour

                // Add the cookie to the response
                Response.Cookies.Add(userInfoCookie);

                return RedirectToAction("AddPublication", "JobPublications");
            }
            else
            {
                TempData["SuccessMessage"] = "User don't exist. Please SignUp";
                return RedirectToAction("Login");
            }
        }

        public ActionResult ValidateJobToken()
        {
            HttpCookie userInfoCookie = Request.Cookies["UserInfo"];

            // Check if the cookie exists and if it contains the "UserID" key
            if (userInfoCookie != null && userInfoCookie["UserID"] != null)
            {
                int userId;
                if (int.TryParse(userInfoCookie["UserID"], out userId)) { 

                    GuestUserToken guestUserToken = db.userToken.FirstOrDefault(u => u.UserID == userId.ToString());

                    if (guestUserToken.ExpiresOn > DateTime.Now)
                    {
                        guestUserToken.ExpiresOn = guestUserToken.ExpiresOn.AddMinutes(30);
                        db.SaveChanges();
                        return null;

                    }
                    else
                    {
                        guestUserToken.ExpiresOn = guestUserToken.ExpiresOn.AddMinutes(30);
                        db.SaveChanges();
                        return null;
                    }

                }
                return null;

            }
            else
            {
                return RedirectToAction("Login", "Auth"); // Redirect to the login page
            }

        }


        public ActionResult Logout()
        {
            // Expire the authentication cookie
            HttpCookie userInfoCookie = HttpContext.Response.Cookies["UserInfo"];
            if (userInfoCookie != null)
            {
                userInfoCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Response.Cookies.Add(userInfoCookie);
            }

            // Redirect to the login page
            return RedirectToAction("Login", "Auth");
        }
    }
}