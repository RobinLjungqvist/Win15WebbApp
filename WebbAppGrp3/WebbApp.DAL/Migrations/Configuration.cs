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
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebbApp.DAL.ApplicationContext";
        }

        protected override void Seed(WebbApp.DAL.ApplicationContext context)
        {
            List<City> cityList = new List<City> {
                    new City() { CityId = Guid.NewGuid(), CityName = "Helsingborg" },
                    new City() { CityId = Guid.NewGuid(), CityName = "Lund" },
                    new City() { CityId = Guid.NewGuid(), CityName = "Malm�" },
             };

            foreach (City i in cityList)
            {
                context.Cities.AddOrUpdate(x => x.CityId, i);
            }

            DateTime date = DateTime.Today;
            List<Item> itemList = new List<Item> {
                                new Item() { ItemID = Guid.NewGuid(), Title = "Bord", Description = "", CreateDate = date,             ExpirationDate = date.AddDays(7) } ,
                                new Item() { ItemID = Guid.NewGuid(), Title = "Chair", Description = "", CreateDate = date.AddDays(-1), ExpirationDate = date.AddDays(6) } ,
                                new Item() { ItemID = Guid.NewGuid(), Title = "Cupboard", Description = "", CreateDate = date.AddDays(-3), ExpirationDate = date.AddDays(4)}
                };

            foreach (Item i in itemList)
            {
                context.Items.AddOrUpdate(x => x.ItemID, i);
            }

            var condition1 = new Condition() { ConditionId = Guid.NewGuid(), Status = "Worn" };
            var condition2 = new Condition() { ConditionId = Guid.NewGuid(), Status = "Hardly used" };
            context.Conditions.AddOrUpdate(x => x.ConditionId, condition1, condition2);

            var category1 = new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Furniture" };
            var category2 = new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Books" };
            context.Categories.AddOrUpdate(x => x.CategoryId, category1, category2);

            var image1 = new Image() { ImageId = Guid.NewGuid(), Path = "sg" };
            context.Images.AddOrUpdate(x => x.ImageId, image1);

            List<Region> regionList = new List<Region> {
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Blekinge" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Dalarna" },
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
        }
    }
}
