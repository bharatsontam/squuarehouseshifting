using SquareHouseShifting.Models;
using SquareHouseShifting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquareHouseShifting.Controllers
{
    public class QuotesController : Controller
    {
        // GET: Quotes
        public ActionResult Index()
        {
            QuoteRepository repo = new QuoteRepository();
            string userid = null;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                userid = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            }
            var list = repo.GetQuotesList(userid);
            return View(list);
        }
    }
}