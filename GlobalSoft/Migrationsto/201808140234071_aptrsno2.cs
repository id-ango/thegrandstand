namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aptrsno2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AptTrsNoes", "GlAkunID", c => c.Int(nullable: false));
            DropColumn("dbo.AptTrsNoes", "NoUrut");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AptTrsNoes", "NoUrut", c => c.Int(nullable: false));
            DropColumn("dbo.AptTrsNoes", "GlAkunID");
        }
    }
}
