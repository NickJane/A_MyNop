using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApi.ViewModels
{
    public class ApiResultModel
    { 
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public dynamic Data { get; set; }
    }
}