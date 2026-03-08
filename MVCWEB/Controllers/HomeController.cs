using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCWEB.Models;

namespace MVCWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            try
            {
                _dbContext.SaveChanges();
                _logger.LogInformation("GEGEGE");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error saving database");
            }
            return View();
        }

        public IActionResult Privacy()
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
