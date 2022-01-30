using FreeCourse.Shared.Services;
using FreeCourse.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICatalogService _courseService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public CoursesController(ICatalogService courseService, ISharedIdentityService sharedIdentityService)
        {
            _courseService = courseService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _courseService.GetAllCourseByUserIdAsync(_sharedIdentityService.GetUserId));
        }
    }
}
