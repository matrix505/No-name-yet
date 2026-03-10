using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using MVCWEB.Models;
using MVCWEB.Services.Abstract;

namespace MVCWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;

        public HomeController(
            ILogger<HomeController> logger,
            IItemService itemService
            )
        {
            _logger = logger;
            _itemService = itemService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _itemService.GetItems();

            return View(items);
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
