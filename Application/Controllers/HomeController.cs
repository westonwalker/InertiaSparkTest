using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InertiaSparkTest.Application.Database;
using InertiaSparkTest.Application.ViewModels;
using System.Diagnostics;
using ILogger = Spark.Library.Logging.ILogger;

namespace InertiaSparkTest.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
		private readonly DatabaseContext _db;

		public HomeController(ILogger logger, DatabaseContext db)
        {
            _logger = logger;
			_db = db;
        }

        [Route("")]
        public IActionResult Index()
		{
			return View();
        }

		[Authorize]
		[Route("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}