namespace WebbApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "UserId");
        }
    }
}
