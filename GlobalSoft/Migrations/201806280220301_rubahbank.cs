namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rubahbank : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CbBanks", "BankType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CbBanks", "BankType", c => c.Int(nullable: false));
        }
    }
}
