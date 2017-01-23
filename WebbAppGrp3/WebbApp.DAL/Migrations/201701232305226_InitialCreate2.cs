namespace WebbApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "Item_ItemID", c => c.Guid());
            AddColumn("dbo.Image", "Item_ItemID1", c => c.Guid());
            CreateIndex("dbo.Image", "Item_ItemID");
            CreateIndex("dbo.Image", "Item_ItemID1");
            AddForeignKey("dbo.Image", "Item_ItemID", "dbo.Item", "ItemID");
            AddForeignKey("dbo.Image", "Item_ItemID1", "dbo.Item", "ItemID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "Item_ItemID1", "dbo.Item");
            DropForeignKey("dbo.Image", "Item_ItemID", "dbo.Item");
            DropIndex("dbo.Image", new[] { "Item_ItemID1" });
            DropIndex("dbo.Image", new[] { "Item_ItemID" });
            DropColumn("dbo.Image", "Item_ItemID1");
            DropColumn("dbo.Image", "Item_ItemID");
        }
    }
}
