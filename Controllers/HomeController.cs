using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebBilirTask2.Models;
using WebBilirTask2.Models.Concrete.Entity;

namespace WebBilirTask2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Context db = new Context();

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

        public IActionResult Deneme(Card card)
        {
            var value = db.Cards.ToList();
            if (card.Title == null)
            {
                return View(value);
            }
            db.Cards.Add(card);
            db.SaveChanges();
            return View(value);
        }

        public ActionResult DeleteButton(int id)
        {
            var deletedItem = db.Cards.Find(id);
            db.Cards.Remove(deletedItem);
            db.SaveChanges();
            return RedirectToAction("Deneme");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
