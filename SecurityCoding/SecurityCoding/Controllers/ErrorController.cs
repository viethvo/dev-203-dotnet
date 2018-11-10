using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityCoding.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

        public ViewResult Forbidden()
        {
            Response.StatusCode = 403;
            return View("Forbidden");
        }

        public ViewResult ServerError()
        {
            Response.StatusCode = 500;
            return View("ServerError");
        }
    }
}