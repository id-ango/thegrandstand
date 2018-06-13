namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusold : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AptUnits", "StatOld", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AptUnits", "StatOld");
        }
    }
}
