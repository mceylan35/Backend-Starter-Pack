using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.MvcWebUI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [HttpPost]
        [Route("sadasd")]
        public ActionResult Index()
        {
            return View();
        }
    }
}