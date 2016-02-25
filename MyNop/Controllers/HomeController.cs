using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nop.Data;

namespace MyNop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            NopObjectContext a = new NopObjectContext();
            var name = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserName;
            name = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().Auth_Roles.FirstOrDefault().RoleName;
            return Content("");
        }
	}
}