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
    public class QuoteMap : EntityTypeConfiguration<Quote>
    {
        public QuoteMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.StartAddress);
            Property(t => t.EndAddress);
            Property(t => t.Distance);
            Property(t => t.QuoteInfo);
            Property(t => t.QuotePrice);
            Property(t => t.IsPurchased);
            Property(t => t.CreateTimeStamp);
            Property(t => t.PurchaseTimeStamp);
            Property(t => t.UserId);

            ToTable("Quotes");
        }
    }
}
