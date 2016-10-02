using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareHouseShifting.Data.Models
{
    public class Quote
    {
        [Key]
        public Guid Id { get; set; }

        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public string Distance { get; set; }
        public bool IsPurchased { get; set; }

        public string QuoteInfo { get; set; }
        public decimal QuotePrice { get; set; }

        public DateTime CreateTimeStamp { get; set; }
        public DateTime? PurchaseTimeStamp { get; set; }

        public string UserId { get; set; }

    }
}
