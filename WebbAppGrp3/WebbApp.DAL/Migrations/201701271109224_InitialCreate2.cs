namespace WebbApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Image", "Path", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Image", "Path", c => c.String(nullable: false));
        }
    }
}
