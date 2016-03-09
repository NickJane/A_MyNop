using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNop.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Admin/Account/
        public ActionResult Index()
        {
            return Content("这是admin区域的account/index");
            //return View();
        }
	}
}