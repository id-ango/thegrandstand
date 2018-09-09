namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guidcb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CbTransDs", "GuidDb", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CbTransDs", "GuidDb");
        }
    }
}
