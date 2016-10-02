namespace SquareHouseShifting.Migrations.EFDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        StartAddress = c.String(),
                        EndAddress = c.String(),
                        Distance = c.String(),
                        IsPurchased = c.Boolean(nullable: false),
                        QuoteInfo = c.String(),
                        QuotePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        PurchaseTimeStamp = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quotes");
        }
    }
}
