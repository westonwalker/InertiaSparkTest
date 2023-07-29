using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InertiaSparkTest.Application.Database;
using InertiaSparkTest.Application.ViewModels;
using System.Diagnostics;
using ILogger = Spark.Library.Logging.ILogger;
using InertiaCore;
using Microsoft.Identity.Client;

namespace InertiaSparkTest.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
		private readonly DatabaseContext _db;
        private static List<string> characters = new() { "Jerry" };

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var componentName = "Welcome";
            return Inertia.Render(componentName, new { });
        }

        [HttpGet]
        [Route("counter")]
        public IActionResult Counter()
        {
            var componentName = "Counter";
            return Inertia.Render(componentName, new { });
        }

        [HttpGet]
        [Route("characters")]
        public IActionResult Characters()
        {
            var componentName = "Characters";
            //return whatever you want.
            var props = new { characters };
            //return Inertia Result.
            return Inertia.Render(componentName, props);
        }

        public class MyPayload
        {
            public string name { get; set; }
        }

        [HttpPost]
        [Route("/characters")]
        public IActionResult Users([FromBody] MyPayload payload)
        {
            characters.Add(payload.name);
            return RedirectToAction("Characters", "Home");
        }

        [Authorize]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            var componentName = "Dashboard";
            return Inertia.Render(componentName, new { });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}