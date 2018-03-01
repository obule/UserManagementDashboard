using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewEmployeeService.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "Hello Fro Test Controller";
        }
    }
}
