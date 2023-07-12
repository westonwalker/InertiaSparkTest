using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InertiaSparkTest.Application.Models;

namespace InertiaSparkTest.Application.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Authorize(Policy = CustomRoles.Admin)]
        [Route("admin/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
