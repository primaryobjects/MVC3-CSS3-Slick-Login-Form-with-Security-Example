using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginFormExample.Attributes;
using LoginFormExample.Models;
using System.Web.Security;

namespace LoginFormExample.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            // If user has already logged in, redirect to the secure area.
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Secure");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(LogOnModel model, string returnUrl)
        {
            // Verify the fields.
            if (ModelState.IsValid)
            {
                // Validate the user login.
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    // Create the authentication ticket.
                    FormsAuthentication.SetAuthCookie(model.Username, false);

                    // Redirect to the secure area.
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Secure");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            // Delete the user details from cache.
            System.Web.HttpContext.Current.Cache.Remove(User.Identity.Name);

            // Delete the authentication ticket and sign out.
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
