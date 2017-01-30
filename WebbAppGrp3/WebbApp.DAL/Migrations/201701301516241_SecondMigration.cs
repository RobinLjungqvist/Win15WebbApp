namespace WebbApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Item", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "UserId", c => c.String());
        }
    }
}
