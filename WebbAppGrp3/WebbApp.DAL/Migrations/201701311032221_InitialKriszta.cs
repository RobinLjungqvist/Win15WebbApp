namespace WebbApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIDonItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "ApplicationUserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "ApplicationUserId");
        }
    }
}
