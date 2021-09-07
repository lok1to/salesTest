namespace Sales.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_totalTaxAmount_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "TotalTaxAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "TotalTaxAmount");
        }
    }
}
