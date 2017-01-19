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