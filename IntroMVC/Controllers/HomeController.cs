using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IntroMVC.Models;

namespace IntroMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var homeModelInstance = new HomeModel
        {
            Name = "Pepe",
            Age = 23
        };

        var anonymHomeModel = new {Name = "Juan"};

        _logger.LogDebug("rendering home index");

        return View(homeModelInstance);
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
