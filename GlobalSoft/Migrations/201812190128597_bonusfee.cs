namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bonusfee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArAkunSets", "GlAkunID5", c => c.Int(nullable: false));
            AddColumn("dbo.ArAkunSets", "GlAkun5", c => c.String());
            AddColumn("dbo.ArAkunSets", "GlAkunI5_GlAkunID", c => c.Int());
            CreateIndex("dbo.ArAkunSets", "GlAkunI5_GlAkunID");
            AddForeignKey("dbo.ArAkunSets", "GlAkunI5_GlAkunID", "dbo.GlAccounts", "GlAkunID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArAkunSets", "GlAkunI5_GlAkunID", "dbo.GlAccounts");
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI5_GlAkunID" });
            DropColumn("dbo.ArAkunSets", "GlAkunI5_GlAkunID");
            DropColumn("dbo.ArAkunSets", "GlAkun5");
            DropColumn("dbo.ArAkunSets", "GlAkunID5");
        }
    }
}
