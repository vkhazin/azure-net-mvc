using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace azure_net_mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var webMsg = System.Environment.MachineName;
            ViewData["WebMsg"] = webMsg;
            ViewData["Message"] = DateTime.UtcNow.ToString("O");
            return View();
        }
    }
}