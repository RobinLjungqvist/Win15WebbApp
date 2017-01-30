namespace WebbApp.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebbApp.DAL.DB.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebbApp.DAL.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebbApp.DAL.ApplicationContext context)
        {
            Guid CityId1 = Guid.NewGuid();
            Guid CityId2 = Guid.NewGuid();
            Guid CityId3 = Guid.NewGuid();

            List<City> cityList = new List<City> {
                    new City() { CityId = CityId1, CityName = "Helsingborg" },
                    new City() { CityId = CityId2, CityName = "Lund" },
                    new City() { CityId = CityId3, CityName = "Malm�" },
             };

            foreach (City i in cityList)
            {
                context.Cities.AddOrUpdate(x => x.CityId, i);
            }

            Guid ConditionId1 = Guid.NewGuid();
            Guid ConditionId2 = Guid.NewGuid();

            var condition1 = new Condition() { ConditionId = ConditionId1, Status = "Worn" };
            var condition2 = new Condition() { ConditionId = ConditionId2, Status = "Hardly used" };
            context.Conditions.AddOrUpdate(x => x.ConditionId, condition1, condition2);

            Guid CategoryId1 = Guid.NewGuid();
            Guid CategoryId2 = Guid.NewGuid();

            var category1 = new Category() { CategoryId = CategoryId1, CategoryName = "Furniture" };
            var category2 = new Category() { CategoryId = CategoryId2, CategoryName = "Books" };
            context.Categories.AddOrUpdate(x => x.CategoryId, category1, category2);

            Guid RegionId1 = Guid.NewGuid();
            Guid RegionId2 = Guid.NewGuid();


            List<Region> regionList = new List<Region> {
                   new Region() { RegionId = RegionId1, RegionName = "Blekinge" },
                   new Region() { RegionId = RegionId2, RegionName = "Dalarna" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Gotland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "G�vleborg" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Halland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "J�mtland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "J�nk�ping" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Kalmar" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Kronoberg" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Norrbotten" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Sk�ne" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Stockholm" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "S�dermanland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Uppsala" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "V�rmland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "V�sterbotten" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "V�stmanland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "V�stra G�taland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "�rebro" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "�sterg�tland" }
            };

            foreach (Region i in regionList)
            {
                context.Regions.AddOrUpdate(x => x.RegionId, i);
            }

            var ItemID1 = Guid.NewGuid();
            var ItemID2 = Guid.NewGuid();
            var ItemID3 = Guid.NewGuid();

            DateTime date = DateTime.Today;
            List<Item> itemList = new List<Item> {
                                new Item() { ItemID = ItemID1, Title = "Bord", Description = "",
                                    CreateDate = date, ExpirationDate = date.AddDays(7),
                                    CategoryId = CategoryId1, ConditionId = ConditionId1, RegionId = RegionId1, CityId = CityId1 } ,
                                new Item() { ItemID = ItemID2, Title = "Chair", Description = "", CreateDate = date.AddDays(-1), ExpirationDate = date.AddDays(6),
                                    CategoryId = CategoryId2, ConditionId = ConditionId2, RegionId = RegionId1, CityId = CityId1} ,
                                new Item() { ItemID = ItemID3, Title = "Cupboard", Description = "", CreateDate = date.AddDays(-3), ExpirationDate = date.AddDays(4),
                                    CategoryId = CategoryId2, ConditionId = ConditionId1, RegionId = RegionId2, CityId = CityId2}
                };

            foreach (Item i in itemList)
            {
                context.Items.AddOrUpdate(x => x.ItemID, i);
            }

            Guid ImageId1 = Guid.NewGuid();

            var image1 = new Image() { ImageId = ImageId1, Path = "../Images/PlaceholderImage.png", ItemID = ItemID1 };
            context.Images.AddOrUpdate(x => x.ImageId, image1);
            var image2 = new Image() { ImageId = Guid.NewGuid(), Path = "../Images/PlaceholderImage.png", ItemID = ItemID2 };
            context.Images.AddOrUpdate(x => x.ImageId, image2);
            var image3 = new Image() { ImageId = Guid.NewGuid(), Path = "../Images/PlaceholderImage.png", ItemID = ItemID3 };
            context.Images.AddOrUpdate(x => x.ImageId, image3);
        }

    }
}

