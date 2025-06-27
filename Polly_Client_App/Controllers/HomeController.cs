using Microsoft.AspNetCore.Mvc;
using Polly_Client_App.Models;
using System.Diagnostics;

namespace Polly_Client_App.Controllers
{
    public class HomeController : Controller
    {


        private readonly ProductService _productService;
        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var lstnumber = await _productService.GetLstNumber();
            ViewBag.LstNumber = lstnumber;
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