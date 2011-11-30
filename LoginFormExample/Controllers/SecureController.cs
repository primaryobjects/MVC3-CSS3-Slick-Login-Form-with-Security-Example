using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginFormExample.Models;

namespace LoginFormExample.Controllers
{
    public class SecureController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
