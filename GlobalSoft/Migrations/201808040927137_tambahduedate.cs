namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahduedate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PiutangDetails", "Duedate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PiutangDetails", "TglString", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PiutangDetails", "TglString");
            DropColumn("dbo.PiutangDetails", "Duedate");
        }
    }
}
