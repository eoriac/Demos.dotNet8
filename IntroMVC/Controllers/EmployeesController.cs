using Microsoft.AspNetCore.Mvc;

namespace IntroMVC;

public class EmployeesController  : Controller
{
    private readonly ILogger<EmployeesController> logger;

    public EmployeesController(ILogger<EmployeesController> logger)
    {
        this.logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Employee employee)
    {
        // ....
        return View();
    }
}
