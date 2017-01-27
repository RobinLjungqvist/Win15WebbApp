namespace WebbApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemID = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CityId = c.Guid(nullable: false),
                        ConditionId = c.Guid(nullable: false),
                        RegionId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Condition", t => t.ConditionId, cascadeDelete: true)
                .ForeignKey("dbo.Region", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.ConditionId)
                .Index(t => t.RegionId)
                .Index(t => t.CategoryId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        UserRole = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Guid(nullable: false),
                        CityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Condition",
                c => new
                    {
                        ConditionId = c.Guid(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ConditionId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageId = c.Guid(nullable: false),
                        Path = c.String(nullable: false),
                        ItemID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Item", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionId = c.Guid(nullable: false),
                        RegionName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Item", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Image", "ItemID", "dbo.Item");
            DropForeignKey("dbo.Item", "ConditionId", "dbo.Condition");
            DropForeignKey("dbo.Item", "CityId", "dbo.City");
            DropForeignKey("dbo.Item", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Item", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Image", new[] { "ItemID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Item", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Item", new[] { "CategoryId" });
            DropIndex("dbo.Item", new[] { "RegionId" });
            DropIndex("dbo.Item", new[] { "ConditionId" });
            DropIndex("dbo.Item", new[] { "CityId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Region");
            DropTable("dbo.Image");
            DropTable("dbo.Condition");
            DropTable("dbo.City");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Item");
            DropTable("dbo.Category");
        }
    }
}
