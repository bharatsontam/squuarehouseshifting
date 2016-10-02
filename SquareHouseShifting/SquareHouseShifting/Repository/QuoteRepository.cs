using SquareHouseShifting.Data.Models;
using SquareHouseShifting.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SquareHouseShifting.Repository
{
    public class QuoteRepository
    {
        public QuoteDetailsViewModel GenerateQuote(string start, string end, string distance, string userName)
        {
            QuoteDetailsViewModel quote = new QuoteDetailsViewModel();
            decimal totalPrice = 0;
            quote.StartAddress = start;
            quote.EndAddress = end;
            quote.IsPurchased = false;
            quote.Distance = distance;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                quote.UserId = db.Users.FirstOrDefault(x => x.UserName == userName).Id;
            }

            quote.QuoteInfoList = new List<QuoteInfo>();

            var shiftingCharges = Decimal.Round(Convert.ToDecimal(ConfigurationManager.AppSettings["LifitingCharges"].ToString()), 2);
            quote.QuoteInfoList.Add(new QuoteInfo { Key = "LifitingCharges", value = shiftingCharges });
            totalPrice += shiftingCharges;
            var packingCharges = Decimal.Round(Convert.ToDecimal(ConfigurationManager.AppSettings["PackingCharges"].ToString()), 2);
            quote.QuoteInfoList.Add(new QuoteInfo { Key = "PackingCharges", value = packingCharges });
            totalPrice += packingCharges;

            var travellingCharges = Decimal.Round(Convert.ToDecimal(ConfigurationManager.AppSettings["TravellingCostperMile"].ToString()) * Convert.ToDecimal(distance), 2);
            quote.QuoteInfoList.Add(new QuoteInfo { Key = "TravellingCharges", value = travellingCharges });
            totalPrice += travellingCharges;

            var gasCharges = Decimal.Round((totalPrice * Convert.ToInt16(ConfigurationManager.AppSettings["GasChargesPercent"].ToString())) / 100, 2);
            quote.QuoteInfoList.Add(new QuoteInfo { Key = "GasCharges", value = gasCharges });
            totalPrice += gasCharges;

            var serviceCharges = Decimal.Round((totalPrice * Convert.ToInt16(ConfigurationManager.AppSettings["ServiceChargesPercent"].ToString())) / 100, 2);
            quote.QuoteInfoList.Add(new QuoteInfo { Key = "ServiceCharges", value = serviceCharges });
            totalPrice += serviceCharges;

            var taxes = Decimal.Round((totalPrice * Convert.ToInt16(ConfigurationManager.AppSettings["TaxesPercent"].ToString())) / 100, 2);
            quote.QuoteInfoList.Add(new QuoteInfo { Key = "Taxes", value = taxes });
            totalPrice += taxes;

            quote.QuotePrice = totalPrice;

            using (EFDbContext db = new EFDbContext())
            {
                Quote _quote = new Quote
                {
                    StartAddress = quote.StartAddress,
                    EndAddress = quote.EndAddress,
                    Distance = quote.Distance,
                    IsPurchased = quote.IsPurchased,
                    CreateTimeStamp = DateTime.Now,
                    QuotePrice = quote.QuotePrice,
                    QuoteInfo = string.Join(",", quote.QuoteInfoList.Select(x => x.Key + "=" + x.value).ToArray()),
                    UserId = quote.UserId
                };

                db.Entry(_quote).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();

                quote.Id = _quote.Id;
            }

            return quote;
        }

        public QuoteViewModel GetQuoteById(Guid id)
        {
            QuoteViewModel model = new QuoteViewModel();
            Quote quote = new Quote();
            using (EFDbContext db = new EFDbContext())
            {
                quote = db.Quotes.FirstOrDefault(q => q.Id == (id));
            }
            model.Id = quote.Id;
            model.Distance = quote.Distance;
            model.EndAddress = quote.EndAddress;
            model.StartAddress = quote.StartAddress;
            model.UserId = quote.UserId;
            model.IsPurchased = quote.IsPurchased;
            model.QuoteInfoList = new List<QuoteInfo>();
            foreach (var info in quote.QuoteInfo.Split(',').ToList())
            {
                model.QuoteInfoList.Add(new QuoteInfo
                {
                    Key = info.Split('=')[0],
                    value = Convert.ToDecimal(info.Split('=')[1])
                });
            }
            model.QuotePrice = quote.QuotePrice;

            return model;
        }

        public IList<QuoteViewModel> GetQuotesList(string userId)
        {
            IList<Quote> quoteList = new List<Quote>();
            IList<QuoteViewModel> list = new List<QuoteViewModel>();
            using (EFDbContext db = new EFDbContext())
            {
                quoteList = db.Quotes.Where(x => x.UserId == userId).ToList();
            }
            foreach (var quote in quoteList)
            {
                QuoteViewModel quoteModel = new QuoteViewModel();
                quoteModel.Distance = quote.Distance;
                quoteModel.EndAddress = quote.EndAddress;
                quoteModel.Id = quote.Id;
                quoteModel.IsPurchased = quote.IsPurchased;
                quoteModel.QuotePrice = quote.QuotePrice;
                quoteModel.StartAddress = quote.StartAddress;
                quoteModel.UserId = quote.UserId;
                quoteModel.QuoteInfoList = new List<QuoteInfo>();

                foreach (var info in quote.QuoteInfo.Split(','))
                {
                    quoteModel.QuoteInfoList.Add(new QuoteInfo
                    {
                        Key = info.Split('=')[0],
                        value = Convert.ToDecimal(info.Split('=')[1])
                    });
                }
                list.Add(quoteModel);
            }
            return list;
        }
    }
}