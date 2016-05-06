using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nop.Core.Domain;
using Nop.Services;
using MyApi.ViewModels;

namespace MyApi.Controllers
{
    public class UsersController : BaseController
    {
        private Nop.Services.Users.IUserService _userService;
        public UsersController(Nop.Services.Users.IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ApiResultModel GetUsers(dynamic model) { 
            ApiResultModel result=new ApiResultModel();
            if (model.EntityPager == null)
                result.Data = _userService.Table.ToList();

            return result;
        }
    }
}