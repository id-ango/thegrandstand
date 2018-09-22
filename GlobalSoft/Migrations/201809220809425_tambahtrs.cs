namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahtrs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AptTrsNoes", "TransNo", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AptTrsNoes", "TransNo", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
