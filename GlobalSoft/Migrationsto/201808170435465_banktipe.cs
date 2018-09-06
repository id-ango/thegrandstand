namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banktipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CbBanks", "BankType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CbBanks", "BankType");
        }
    }
}
