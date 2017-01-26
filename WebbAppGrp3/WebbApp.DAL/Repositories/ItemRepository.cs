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

        //TODO add city, category osv
        public void Add(Item entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Items.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(Item entity)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Items.Where(p => p.ItemID == entity.ItemID).FirstOrDefault();
                item.Title = entity.Title;
                item.Region = entity.Region;
                item.Image = entity.Image;
                context.SaveChanges();
            }
        }

        //TODO cascading delete
        public void Delete(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                context.Items.Remove(context.Items.Where<Item>(p => p.ItemID == id).FirstOrDefault());
                context.SaveChanges();
            }
        }

        //TODO cascading delete
        public void Delete(Item entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Items.Remove(context.Items.Where<Item>(p => p.ItemID == entity.ItemID).FirstOrDefault());
                context.SaveChanges();
            }
        }

        public IQueryable<Item> GetAll()
        {
            using (var context = new ApplicationContext())
            {
                return context.Items.Select(s => s);
            }
        }

        public Item GetById(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Items.Where(p => p.ItemID == id).FirstOrDefault();
                return item;
            }
        }

        public IQueryable<Item> Search(string searchTerm)
        {
            //sb.Append(" WHERE Quantity > 0 AND ModelName LIKE @search OR Brand LIKE @search OR ShoeType LIKE @search");
            //sb.Append(" OR Material LIKE @search OR Category Like @search");
            //using (var context = new ApplicationContext())
            //{
            //    var item = context.Items.Where(p => p);
            //    return item;
            //}
            throw new NotImplementedException();
        }

        public IQueryable<Item> FilteredSearch(Item Searchable)
        {
            throw new NotImplementedException();
        }
    }
}
