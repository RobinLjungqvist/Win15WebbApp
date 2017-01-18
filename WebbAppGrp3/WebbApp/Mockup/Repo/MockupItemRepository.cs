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
        public void CreateOrUpdateItem(MockupItem item)
        {
            throw new NotImplementedException();
        }

        public List<MockupItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public MockupItem GetItemByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public MockupItem GetItemByRegion(string Region)
        {
            throw new NotImplementedException();
        }

        public void RemoveItemByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}