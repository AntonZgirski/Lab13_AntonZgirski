using _16_ASP.NET_Practice_01_02_2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Data;

namespace _16_ASP.NET_Practice_01_02_2023.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly WorkWithFile _file;
    private readonly string path = @"List.xml";

    public HomeController(ILogger<HomeController> logger, WorkWithFile file)
    {
      _logger = logger;
      _file = file;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]    
    public IActionResult Reg()
    { 
      return View(); 
    }


    [HttpPost]
    public IActionResult Create([FromForm] string brand, [FromForm] string model, [FromForm] string year, [FromForm] string price)
    {
      List<Auto> lauto = new List<Auto>();      
      FileInfo fileInf = new FileInfo(path);

      if (fileInf.Exists) lauto = _file.DeserializeList(path);      
      var a = new Auto(_file.GenerateId() ,brand, model, year, price);
      lauto.Add(a);

      _file.SerealizeList(lauto, path);
      
      return RedirectToAction("Index");
    }
        
    public IActionResult Display()
    {      
      return View(_file.DeserializeList(path));
    }

    public IActionResult DeleteAuto(string id)
    {
      List<Auto> lauto = new List<Auto>();      
      lauto = _file.DeserializeList(path);
      lauto.Remove(lauto.Find(Auto => Auto.Id == id));
      _file.SerealizeList(lauto,path);
      return RedirectToAction("Display");
    }

    [HttpPost]
    public IActionResult Display([FromForm] string brand)
    {
      List<Auto> lauto = new List<Auto>();
      List<Auto> fauto = new List<Auto>();
      lauto = _file.DeserializeList(path);
      foreach(var a in lauto)
      {
        if (a.Brand == brand)
        {
          fauto.Add(a);
        }
      }
      return View(fauto);
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