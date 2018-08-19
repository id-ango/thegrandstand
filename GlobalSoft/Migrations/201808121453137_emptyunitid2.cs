namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emptyunitid2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PiutangMains", "BankID", "dbo.CbBanks");
            DropIndex("dbo.PiutangMains", new[] { "BankID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PiutangMains", "BankID");
            AddForeignKey("dbo.PiutangMains", "BankID", "dbo.CbBanks", "BankID", cascadeDelete: true);
        }
    }
}
