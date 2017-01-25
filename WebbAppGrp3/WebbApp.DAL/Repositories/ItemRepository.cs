using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL.Interfaces;
using System.IO;

namespace WebbApp.DAL.Repositories
{
    class ItemRepository : ISearchableRepository<Item>
    {
        private ApplicationContext ctx;

        public ItemRepository()
        {
            this.ctx = new ApplicationContext();
        }

        public void Add(Item entity)
        {
            throw new NotImplementedException();
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
