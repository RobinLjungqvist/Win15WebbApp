using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL.Interfaces;

namespace WebbApp.DAL.Repositories
{
    class ItemRepository : ISearchable<Item>
    {
        private ApplicationContext ctx;

        public ItemRepository()
        {
            this.ctx = new ApplicationContext();
        }

        public void Add(Item entity)
        {
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Item entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Item> FilteredSearch(Item Searchable)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public Item GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Item> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
