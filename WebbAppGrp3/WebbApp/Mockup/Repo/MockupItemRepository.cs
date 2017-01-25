using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebbApp.Mockup.Interfaces;
using WebbApp.Mockup.Models;

namespace WebbApp.Mockup.Repo
{
    public class MockupItemRepository : IItemRepository
    {
        static List<MockupItem> ListOfItem = new List<MockupItem>();
        public MockupItemRepository()
        {
            if (!ListOfItem.Any()) { 
            ListOfItem.Add(new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityMalmö", "ConditionNormal", "RegionSkåne", "CategoryBed", "../Images/PlaceholderImage.png"));
            ListOfItem.Add(new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityHalmstad", "ConditionNormal", "RegionSkåne", "CategoryBed", "../Images/PlaceholderImage.png"));
            ListOfItem.Add(new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityHelsingborg", "ConditionNormal", "RegionSkåne", "CategoryBed", "../Images/PlaceholderImage.png"));
            ListOfItem.Add(new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityLund", "ConditionNormal", "RegionSkåne", "CategoryBed", "../Images/PlaceholderImage.png"));
            }
        }
         //
        public void CreateOrUpdateItem(MockupItem item)
        {
            var itemToCreateOrUpdate = ListOfItem.Find(x => x.ItemID == item.ItemID);
            if (itemToCreateOrUpdate != null)
            {
                itemToCreateOrUpdate.Title = item.Title;
                itemToCreateOrUpdate.Description = item.Description;
                itemToCreateOrUpdate.CreateDate = DateTime.Today;
                itemToCreateOrUpdate.ExpirationDate = DateTime.Now.AddDays(7);
                itemToCreateOrUpdate.City = item.City;
                itemToCreateOrUpdate.Condition = item.Condition;
                itemToCreateOrUpdate.Region = item.Region;
                itemToCreateOrUpdate.Category = item.Category;
                itemToCreateOrUpdate.Image = item.Image;
            }
            else
            {
                MockupItem mockupItem = new MockupItem(Guid.NewGuid(), item.Title, item.Description, DateTime.Today,
                    DateTime.Now.AddDays(7), item.City, item.Condition, item.Region, item.Category,
                    item.Image);
                ListOfItem.Add(mockupItem);
                
            }

        }

        public List<MockupItem> GetAllItems()
        {
            return ListOfItem;
        }

        public MockupItem GetItemByID(Guid id)
        {
            var showItem = ListOfItem.First(x => x.ItemID == id);
            return showItem;
        }

        public List<MockupItem> GetItemByRegion(string Region)
        {
            var itemRegion = ListOfItem.Where(x => x.Region == Region).ToList();
            return itemRegion;
        }

        public void RemoveItemByID(Guid id)
        {
            var deleteItem = ListOfItem.First(x => x.ItemID == id);
            ListOfItem.Remove(deleteItem);
        }

        public List<MockupItem> SearchItem(MockupItem item)
        {
            throw new NotImplementedException();
        }
    }
}