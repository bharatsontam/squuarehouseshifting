namespace SquareHouseShifting.Migrations.EFDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateQuoteTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "UserId");
        }
    }
}
