using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NumberToWordApp.Models;
using NumberToWordApp.Services;

namespace NumberToWordApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NumberToWordsConverter _converter;

    public HomeController(ILogger<HomeController> logger, NumberToWordsConverter converter)
    {
        _converter = converter;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new NumberConverterViewModel());
    }

    [HttpPost]
    public IActionResult Index(NumberConverterViewModel model)
    {
        if (!decimal.TryParse(model.InputAmount, out var parsedAmount))
        {
            model.Result = "Invalid entry, please enter a number.";
            return View(model);
        }

        model.Result = _converter.Convert(parsedAmount);
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
