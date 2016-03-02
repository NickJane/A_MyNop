using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Nop.Data;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain;
using Nop.Services.Users;

namespace MyNop.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userservice;
        public HomeController(IUserService userservice) {
            this._userservice = userservice;
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //IRepository<Auth_Role> _roleRepository = new Nop.Data.EfRepository<Auth_Role>(new Nop.Data.NopObjectContext());

            //var name = _roleRepository.FullTable.Where(x => x.IsDelete);

            var temp= _userservice.Table.First();


            /*
            NopObjectContext a = new NopObjectContext();
            var name = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserName;
            name = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().Auth_Roles.FirstOrDefault().RoleName;

            var userext = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserExt;

            var address = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserAddresses;

            var resources = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().Auth_Roles
                .First().Auth_Resources;
            */
            return Content("");
        }
	}
}