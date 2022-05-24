using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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


        public async Task<IActionResult> Upload(Card card, IFormFile ImageUrl)
        {
            if (ImageUrl.Length > 0)
            {
                var filepath = Path.Combine(Directory.GetCurrentDirectory());
                string filepathDirectory = filepath + "/wwwroot/Uploads/Images" + ImageUrl.FileName;

                using (var stream = new FileStream(filepathDirectory, FileMode.Create))
                {
                    await ImageUrl.CopyToAsync(stream);
                }
                card.ImageUrl = "/Uploads/Images" + ImageUrl.FileName;
            }
            db.Cards.Add(card);
            db.SaveChanges();

            return RedirectToAction("Deneme");
        }


        public ViewResult Deneme()
        {
            var value = db.Cards.ToList();
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
