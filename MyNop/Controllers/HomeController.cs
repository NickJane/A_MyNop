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
using Nop.Data;

namespace MyNop.Controllers
{
    public class VModel {
       public int Id { get; set; }
       public string pwd { get; set; }
    }
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

            var temp = _userservice.Fetch(x => x.IsDelete, x => x.Asc(user => user.ID))
                .ToList();

            var temp2 = _userservice.Table.OrderByDescending(x => x.ID).Skip(3).Take(5).Select(x => new { x.ID, x.Password }).ToList();
            /*
            NopObjectContext a = new NopObjectContext();
            var name = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserName;
            name = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().Auth_Roles.FirstOrDefault().RoleName;

            var userext = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserExt;

            var address = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().UserAddresses;

            var resources = a.Set<Nop.Core.Domain.UserAccount>().FirstOrDefault().Auth_Roles
                .First().Auth_Resources;
            */
            return Json(temp2,JsonRequestBehavior.AllowGet);
        }

        public ActionResult UseUnitOfWork() {
            //UnitOfWorkFactory.CurrentUnitOfWork.BeginTransaction();
            //NopObjectContext db = UnitOfWorkFactory.CurrentUnitOfWork.Context as NopObjectContext;
            //try {
            //    db.ExecuteSqlCommand("insert into auth_role select 1,0,1,'222'");

            //    db.SaveChanges();
            //    throw new Exception();
            //}
            //catch {
            //    UnitOfWorkFactory.CurrentUnitOfWork.RollBack();
            //}


            UnitOfWorkFactory.CurrentUnitOfWork.BeginTransaction();
            //NopObjectContext db = UnitOfWorkFactory.CurrentUnitOfWork.Context as NopObjectContext;
            try
            {
                var cus = new UserAccount
                {
                    UserName = "111",
                    Password = "111111",
                    SiteID = 1,
                    Active = true,
                    IsDelete = false
                };
                _userservice.Insert(cus, false);

                
                
                throw new Exception();
            }
            catch
            {
                UnitOfWorkFactory.CurrentUnitOfWork.RollBack();
            }
            finally
            {
                if (UnitOfWorkFactory.HasContextOpen())
                {
                    UnitOfWorkFactory.CurrentUnitOfWork.Dispose();
                }
            }

            return Content("");
        }

        public ActionResult TestModelSetting() {
            var temp = _userservice.Table.First();
            temp.SetOneSetting("xiaomi", "jianjialin");
            temp.SetOneSetting("mobile","13900000000");
            temp.SaveSetting();
            _userservice.Update(temp);

            var temp2 = _userservice.Table.First();
            return Content(temp2.AllSettings["xiaomi"]);
        }
	}
}