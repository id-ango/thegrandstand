namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordercustome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdID = c.Int(nullable: false, identity: true),
                        OrderId = c.Guid(nullable: false),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        CustomerId = c.Guid(nullable: false),
                        Customer_CustID = c.Int(),
                    })
                .PrimaryKey(t => t.OrdID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustID)
                .Index(t => t.Customer_CustID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_CustID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_CustID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
