using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SquareHouseShifting.Models
{
    public class PurchaseViewModel
    {
        [Required]
        [Display(Name="Id")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name="QuoteId")]
        public Guid QuoteId { get; set; }
        [Required]
        [Display(Name="UserId")]
        public string UserId { get; set; }
        [Required]
        [Display(Name="Total Price")]
        public decimal TotalPrice { get; set; }
        [Required]
        [Display(Name="Card Type")]
        public CardTypeList CardType { get; set; }
        [Required]
        [Display(Name="Card Number")]
        [StringLength(16)]
        [RegularExpression("([1-9][0-9]*)")]
        public string CardNumber { get; set; }
        [Required]
        [Display(Name="Exp(MM/YY)")]
        public string CardExpiration { get; set; }
        [Required]
        [Display(Name="CVV")]
        public string CVV { get; set; }
        [Display(Name="Billing Address")]
        public string BillingAddress { get; set; }

        [Display(Name="Use Start Address for Billing")]
        public bool IsBillingSameAsStart { get; set; }
    }

    public enum CardTypeList
    {
        MasterCard,
        VISA,
        Discover
    }
}