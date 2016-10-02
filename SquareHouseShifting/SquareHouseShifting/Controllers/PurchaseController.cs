using SquareHouseShifting.Models;
using SquareHouseShifting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquareHouseShifting.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoPurchase(Guid Id, string UserId, decimal QuotePrice)
        {
            PurchaseViewModel model = new PurchaseViewModel();
            model.QuoteId = Id;
            model.UserId = UserId;
            model.TotalPrice = QuotePrice;
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreatePurchase(PurchaseViewModel purchase)
        {
            PurchaseRepository repo = new PurchaseRepository();

            var result = repo.CreatePurchase(purchase);
            return result ? RedirectToAction("PurchaseSuccess") : RedirectToAction("PurchaseFailure");
        }

        public ActionResult PurchaseSuccess()
        {
            return View();
        }

        public ActionResult PurchaseFilure()
        {
            return View();
        }

    }
}