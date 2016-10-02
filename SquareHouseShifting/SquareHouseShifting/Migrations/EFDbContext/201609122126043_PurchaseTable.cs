namespace SquareHouseShifting.Migrations.EFDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        QuoteId = c.Guid(nullable: false),
                        UserId = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CardType = c.String(),
                        CardNumber = c.String(),
                        CardExpiration = c.String(),
                        CVV = c.String(),
                        BillingAddress = c.String(),
                        IsBillingSameAsStart = c.Boolean(nullable: false),
                        IsPurchaseSuccess = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchases");
        }
    }
}
