namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahbank1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CbTransHes", "BankID2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CbTransHes", "BankID2");
        }
    }
}
