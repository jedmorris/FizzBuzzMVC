using System.Diagnostics;
using FizzBuzzMVC.Helper;
using Microsoft.AspNetCore.Mvc;
using FizzBuzzMVC.Models;

namespace FizzBuzzMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult FBPage()
    {
       // create an instance of fizz buzz model 
        FizzBuzz model = new FizzBuzz();

        // set default fizz value  
        model.FizzValue = 3;
        // set default buzz value 
        model.BuzzValue = 5;
        
        return View(model);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult FBPage(FizzBuzz fizzBuzz)
    {
        FizzHelper helper = new();
        fizzBuzz.Results = helper.CalcFizz(fizzBuzz);
        
        return View(fizzBuzz);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}