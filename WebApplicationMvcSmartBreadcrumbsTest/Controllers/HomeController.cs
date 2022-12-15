﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplicationMvcSmartBreadcrumbsTest.Models;

namespace WebApplicationMvcSmartBreadcrumbsTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [DefaultBreadcrumb("首頁")]
    public IActionResult Index()
    {
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