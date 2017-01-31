namespace WebbApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CityID", c => c.String());
            AddColumn("dbo.AspNetUsers", "RegionId", c => c.String());
            AddColumn("dbo.AspNetUsers", "City_CityId", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "Region_RegionId", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "City_CityId");
            CreateIndex("dbo.AspNetUsers", "Region_RegionId");
            AddForeignKey("dbo.AspNetUsers", "City_CityId", "dbo.City", "CityId");
            AddForeignKey("dbo.AspNetUsers", "Region_RegionId", "dbo.Region", "RegionId");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Region", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "Region_RegionId", "dbo.Region");
            DropForeignKey("dbo.AspNetUsers", "City_CityId", "dbo.City");
            DropIndex("dbo.AspNetUsers", new[] { "Region_RegionId" });
            DropIndex("dbo.AspNetUsers", new[] { "City_CityId" });
            DropColumn("dbo.AspNetUsers", "Region_RegionId");
            DropColumn("dbo.AspNetUsers", "City_CityId");
            DropColumn("dbo.AspNetUsers", "RegionId");
            DropColumn("dbo.AspNetUsers", "CityID");
        }
    }
}
