namespace WebbApp.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
        }

        protected override void Seed(WebbApp.DAL.ApplicationContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Admin" };
                user.UserRole = "Admin";
                user.Email = "Admin@Admin.com";

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Admin");
            }




            Guid CityId1 = Guid.NewGuid();
            Guid CityId2 = Guid.NewGuid();
            Guid CityId3 = Guid.NewGuid();

            List<City> cityList = new List<City> {
                    new City() { CityId = CityId1, CityName = "Helsingborg" },
                    new City() { CityId = CityId2, CityName = "Lund" },
                    new City() { CityId = CityId3, CityName = "Malmö" },
             };

            if (!context.Cities.Any())
            {
                foreach (City i in cityList)
                {
                    context.Cities.AddOrUpdate(x => x.CityId, i);
                }
            }








            Guid ConditionId1 = Guid.NewGuid();
            Guid ConditionId2 = Guid.NewGuid();

            var condition1 = new Condition() { ConditionId = ConditionId1, Status = "Worn" };
            var condition2 = new Condition() { ConditionId = ConditionId2, Status = "Hardly used" };
            if (!context.Conditions.Any())
            {
                context.Conditions.AddOrUpdate(x => x.ConditionId, condition1, condition2);
            }

            Guid CategoryId1 = Guid.NewGuid();
            Guid CategoryId2 = Guid.NewGuid();

            var category1 = new Category() { CategoryId = CategoryId1, CategoryName = "Furniture" };
            var category2 = new Category() { CategoryId = CategoryId2, CategoryName = "Books" };
            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(x => x.CategoryId, category1, category2);
            }


            Guid RegionId1 = Guid.NewGuid();
            Guid RegionId2 = Guid.NewGuid();
            List<Region> regionList = new List<Region> {
                   new Region() { RegionId = RegionId1, RegionName = "Blekinge" },
                   new Region() { RegionId = RegionId2, RegionName = "Dalarna" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Gotland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Gävleborg" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Halland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Jämtland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Jönköping" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Kalmar" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Kronoberg" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Norrbotten" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Skåne" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Stockholm" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Södermanland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Uppsala" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Värmland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Västerbotten" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Västmanland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Västra Götaland" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Örebro" },
                   new Region() { RegionId = Guid.NewGuid(), RegionName = "Östergötland" }
            };

            if (!context.Regions.Any())
            {
                foreach (Region i in regionList)
                {
                    context.Regions.AddOrUpdate(x => x.RegionId, i);
                }
            }

            var ItemID1 = Guid.NewGuid();
            var ItemID2 = Guid.NewGuid();
            var ItemID3 = Guid.NewGuid();

            var itemUser = context.Users.FirstOrDefault(x => x.UserName == "Admin");

            DateTime date = DateTime.Today;
            List<Item> itemList = new List<Item> {
                                new Item() { ItemID = ItemID1, Title = "Bokhylla", Description = "En redigt fin bokhylla",
                                    CreateDate = date, ExpirationDate = date.AddDays(7),
                                    CategoryId = CategoryId1, ConditionId = ConditionId1, RegionId = RegionId1, CityId = CityId1, ApplicationUser = itemUser, ApplicationUserId = Guid.Parse(itemUser.Id) } ,
                                new Item() { ItemID = ItemID2, Title = "Bok", Description = "En mysig bok till kvällen", CreateDate = date.AddDays(-1), ExpirationDate = date.AddDays(6),
                                    CategoryId = CategoryId2, ConditionId = ConditionId2, RegionId = RegionId1, CityId = CityId1, ApplicationUser = itemUser, ApplicationUserId = Guid.Parse(itemUser.Id)} ,
                                new Item() { ItemID = ItemID3, Title = "Soffa", Description = "Myssoffa deluxe", CreateDate = date.AddDays(-3), ExpirationDate = date.AddDays(4),
                                    CategoryId = CategoryId1, ConditionId = ConditionId1, RegionId = RegionId2, CityId = CityId2, ApplicationUser = itemUser, ApplicationUserId = Guid.Parse(itemUser.Id)}
                };

            if (!context.Items.Any())
            {
                foreach (Item i in itemList)
                {
                    context.Items.AddOrUpdate(x => x.ItemID, i);
                }
            }

            if (!context.Images.Any())
            {

                var image1 = new Image() { ImageId = Guid.NewGuid(), Path = "../Images/bokhylla.jpg", ItemID = ItemID1 };
                context.Images.AddOrUpdate(x => x.ImageId, image1);
                var image2 = new Image() { ImageId = Guid.NewGuid(), Path = "../Images/book.png", ItemID = ItemID2 };
                context.Images.AddOrUpdate(x => x.ImageId, image2);
                var image3 = new Image() { ImageId = Guid.NewGuid(), Path = "../Images/soffa.jpg", ItemID = ItemID3 };
                context.Images.AddOrUpdate(x => x.ImageId, image3);

            }
        }
    }
}
