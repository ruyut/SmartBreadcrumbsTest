using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace WebApplicationMvcSmartBreadcrumbsTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [DefaultBreadcrumb("Index")]
    public IActionResult Index()
    {
        return View();
    }

    [Breadcrumb("Page1")]
    public IActionResult Page1()
    {
        ViewData["Title"] = "Page1";
        return View();
    }

    private List<string> _list = new List<string> { "a", "b", "c" };

    [Breadcrumb("Page2", FromAction = nameof(Page1))]
    public IActionResult Page2()
    {
        ViewData["Title"] = "Page2";
        return View(_list);
    }

    [Breadcrumb("Page3", FromAction = nameof(Page1))]
    public ActionResult<List<string>> Page3()
    {
        ViewData["Title"] = "Page3 - Can't get the breadcrumb to work";

        return View(_list);
    }
}