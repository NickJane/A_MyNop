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

            var userext = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserExt;

            var address = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserAddresses;

            var resources = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().Auth_Roles
                .First().Auth_Resources;

            return Content("");
        }
	}
}