namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spesananid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PiutangDetails", "SPesananID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PiutangDetails", "SPesananID");
        }
    }
}
