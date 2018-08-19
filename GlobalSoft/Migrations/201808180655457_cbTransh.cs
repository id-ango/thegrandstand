namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cbTransh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CbTransDs", "GuidCb", c => c.Guid(nullable: false));
            AddColumn("dbo.CbTransHes", "GuidCb", c => c.Guid(nullable: false));
            AddColumn("dbo.CbTransHes", "Bank1_BankID", c => c.Int());
            AddColumn("dbo.CbTransHes", "Bank2_BankID", c => c.Int());
            CreateIndex("dbo.CbTransDs", "TranshID");
            CreateIndex("dbo.CbTransHes", "Bank1_BankID");
            CreateIndex("dbo.CbTransHes", "Bank2_BankID");
            AddForeignKey("dbo.CbTransHes", "Bank1_BankID", "dbo.CbBanks", "BankID");
            AddForeignKey("dbo.CbTransHes", "Bank2_BankID", "dbo.CbBanks", "BankID");
            AddForeignKey("dbo.CbTransDs", "TranshID", "dbo.CbTransHes", "TranshID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CbTransDs", "TranshID", "dbo.CbTransHes");
            DropForeignKey("dbo.CbTransHes", "Bank2_BankID", "dbo.CbBanks");
            DropForeignKey("dbo.CbTransHes", "Bank1_BankID", "dbo.CbBanks");
            DropIndex("dbo.CbTransHes", new[] { "Bank2_BankID" });
            DropIndex("dbo.CbTransHes", new[] { "Bank1_BankID" });
            DropIndex("dbo.CbTransDs", new[] { "TranshID" });
            DropColumn("dbo.CbTransHes", "Bank2_BankID");
            DropColumn("dbo.CbTransHes", "Bank1_BankID");
            DropColumn("dbo.CbTransHes", "GuidCb");
            DropColumn("dbo.CbTransDs", "GuidCb");
        }
    }
}
