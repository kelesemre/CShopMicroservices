using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Interfaces
{
    public class IClientCredentialTokenService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
