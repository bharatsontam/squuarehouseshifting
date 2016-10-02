using SquareHouseShifting.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareHouseShifting.Data.Mapping
{
    public class PurchaseMapping : EntityTypeConfiguration<Purchase>
    {
        public PurchaseMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.BillingAddress);
            Property(p => p.CardExpiration);
            Property(p => p.CardNumber);
            Property(p => p.CardType);
            Property(p => p.CVV);
            Property(p => p.IsBillingSameAsStart);
            Property(p => p.IsPurchaseSuccess);
            Property(p => p.QuoteId);
            Property(p => p.TotalPrice);
            Property(p => p.UserId);

            ToTable("Purchases");
        }
    }
}
