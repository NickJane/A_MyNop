using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain;
using Nop.Services.Users;
using Nop.Data;
namespace MyNop.Controllers.api
{
    public class UsersAPIController : ApiController
    {
        private IUserService _userservice;
        private IUserService _userservice2;

        public UsersAPIController(IUserService userservice)
        {
            _userservice = userservice;
            _userservice2 = Nop.Core.Infrastructure.MyEngineContext.Current.Resolve<IUserService>();
        }
        
        [HttpGet]
        public string getName() {
            var b = _userservice2.Table.First();
            //var c = _userservice.Table.First();

            return "zzzzzzzzzzzzz";
        }


    }
}