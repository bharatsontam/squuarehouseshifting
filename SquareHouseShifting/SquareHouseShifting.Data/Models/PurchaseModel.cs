using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareHouseShifting.Data.Models
{
    public class Purchase
    {
        [Key]
        public Guid Id { get; set; }

        public Guid QuoteId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiration { get; set; }
        public string CVV { get; set; }

        public string BillingAddress { get; set; }

        public bool IsBillingSameAsStart { get; set; }

        public bool IsPurchaseSuccess { get; set; }
        
    }
}
