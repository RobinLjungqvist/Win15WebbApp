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
            ListOfItem.Add(new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityMalmö", "ConditionNormal", "RegionSkåne", "CategoryBed", "ImageString"));
            ListOfItem.Add(new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityHalmstad", "ConditionNormal", "RegionSkåne", "CategoryBed", "ImageString"));
            ListOfItem.Add(new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityHelsingborg", "ConditionNormal", "RegionSkåne", "CategoryBed", "ImageString"));
            ListOfItem.Add(new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityLund", "ConditionNormal", "RegionSkåne", "CategoryBed", "ImageString"));
        }
           
        public void CreateOrUpdateItem(MockupItem item)
        {
            throw new NotImplementedException();
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

        public MockupItem GetItemByRegion(string Region)
        {
            throw new NotImplementedException();
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