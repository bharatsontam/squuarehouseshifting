using SquareHouseShifting.Data.Models;
using SquareHouseShifting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquareHouseShifting.Repository
{
    public class PurchaseRepository
    {
        public bool CreatePurchase(PurchaseViewModel model)
        {
            Purchase purchase = new Purchase();

            purchase.CardExpiration = model.CardExpiration;
            purchase.CardNumber = model.CardNumber;
            purchase.CardType = model.CardType.ToString();
            purchase.CVV = model.CVV;
            purchase.IsBillingSameAsStart = model.IsBillingSameAsStart;
            purchase.IsPurchaseSuccess = true;
            purchase.QuoteId = model.QuoteId;
            purchase.TotalPrice = model.TotalPrice;
            purchase.UserId = model.UserId;
            try
            {
                using (EFDbContext db = new EFDbContext())
                {
                    purchase.BillingAddress = model.IsBillingSameAsStart ? db.Quotes.FirstOrDefault(x => x.Id == model.QuoteId).StartAddress : model.BillingAddress;

                    db.Entry(purchase).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();

                    var quote = db.Quotes.FirstOrDefault(x => x.Id == model.QuoteId);
                    quote.IsPurchased = true;
                    quote.PurchaseTimeStamp = DateTime.Now;
                    db.Entry(quote).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return false;
                throw;
            }

            return true;
        }
    }
}