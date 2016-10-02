using SquareHouseShifting.Models;
using SquareHouseShifting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquareHouseShifting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CalculateDistance()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Quote(string start, string end, string distance)
        {
            QuoteRepository repositpory = new QuoteRepository();

            var model = repositpory.GenerateQuote(start, end, distance, User.Identity.Name);



            return RedirectToAction("QuoteDetail", new { id = model.Id });
        }

        public ActionResult QuoteDetail(Guid id)
        {
            QuoteRepository repositpory = new QuoteRepository();

            QuoteDetailsViewModel model = new QuoteDetailsViewModel();

            var quoteInfo = repositpory.GetQuoteById(id);
            var currentUserName = User.Identity.Name;
            ApplicationUser user = new ApplicationUser();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.UserName == currentUserName);
            }

            model.Name = user.FirstName + " " + user.LastName;
            model.Email = user.Email;
            model.Id = quoteInfo.Id;
            model.IsPurchased = quoteInfo.IsPurchased;
            model.QuoteInfoList = quoteInfo.QuoteInfoList;
            model.QuotePrice = quoteInfo.QuotePrice;
            model.StartAddress = quoteInfo.StartAddress;
            model.UserId = quoteInfo.UserId;
            model.Distance = quoteInfo.Distance;
            model.EndAddress = quoteInfo.EndAddress;

            return View(model);
        }


    }
}