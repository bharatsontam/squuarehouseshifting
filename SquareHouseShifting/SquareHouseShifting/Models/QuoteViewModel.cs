using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquareHouseShifting.Models
{
    public class QuoteViewModel
    {
        public Guid Id { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public string Distance { get; set; }
        public IList<QuoteInfo> QuoteInfoList { get; set; }
        public decimal QuotePrice { get; set; }
        public bool IsPurchased { get; set; }
        public string UserId { get; set; }
    }

    public class QuoteInfo
    {
        public string Key { get; set; }
        public decimal value { get; set; }
    }

    public class QuoteDetailsViewModel : QuoteViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}