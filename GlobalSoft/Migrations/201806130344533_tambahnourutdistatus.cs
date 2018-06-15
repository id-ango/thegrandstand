namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahnourutdistatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AptTrsNoes", "NoUrut", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AptTrsNoes", "NoUrut");
        }
    }
}
