using System.Diagnostics;
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
        List<string> fbItems = new List<string>();

        bool Fizz;
        bool Buzz;

        for (int i = 1; i <= 100; i++)
        {
            Fizz = (i % fizzBuzz.FizzValue == 0);
            Buzz = (i % fizzBuzz.BuzzValue == 0);

            if (Fizz == true && Buzz == true)
            {
                fbItems.Add("FizzBuzz");
            } 
            else if (Fizz == true)
            {
                fbItems.Add("Fizz");
            }
            else if (Buzz == true)
            {
                fbItems.Add("Buzz");
            }
            else
            {
                fbItems.Add(i.ToString());
            }
        }

        fizzBuzz.Results = fbItems;
        
        return View(fizzBuzz);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}