namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kodeno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArTransHes", "kodeNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArTransHes", "kodeNo");
        }
    }
}
