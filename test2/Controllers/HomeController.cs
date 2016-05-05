using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test2.Models;

namespace test2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //using (MyContext context = new MyContext())
            //{
            //   string name= context.Set<Student>().FirstOrDefault().Name;
            //   name = context.Set<Student>().FirstOrDefault().Courses.FirstOrDefault().Name;
            //}
            //using (MyContext context = new MyContext())
            //{
            //    string name = context.Set<Student>().FirstOrDefault().Name;
            //    name = context.Set<Student>().FirstOrDefault().Courses.FirstOrDefault().Name;
            //}

            using (SCContext a = new SCContext())
            {
                a.Set<Student>().Add(new Student { Name = "1" });
                a.SaveChanges();
            }
            //using (UserRoleDbContext2 a = new UserRoleDbContext2())
            //{
            //    a.Set<User>().Add(new User { Name = "1" });
            //    a.SaveChanges();
            //}
            return Content("");
        }



	}


}