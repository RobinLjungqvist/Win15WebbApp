using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL.Interfaces;
using System.Data.Entity;
using System.IO;

namespace WebbApp.DAL.Repositories
{
    public class ItemRepository : ISearchableRepository<Item>
    {
        private ApplicationContext ctx;

        public ItemRepository()
        {
            this.ctx = new ApplicationContext();
        }

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
                if (item != null)
                {
                    item.Title = entity.Title;
                    item.Region = entity.Region;
                    item.Image = entity.Image;
                    item.Description = entity.Description;
                    item.CreateDate = entity.CreateDate;
                    item.ExpirationDate = entity.ExpirationDate;
                    item.City = entity.City;
                    item.Condition = entity.Condition;
                    item.Category = entity.Category;
                    item.Image = entity.Image;
                    context.SaveChanges();
                }
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Items.Where<Item>(p => p.ItemID == id)
                    .Include(i => i.City)
                    .Include(i => i.Condition)
                    .Include(i => i.Region)
                    .Include(i => i.Category)
                    .Include(i => i.Image)
                    .FirstOrDefault();
                if (item != null)
                {
                    context.Items.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Delete(Item entity)
        {
            return Delete(entity.ItemID);
        }

        public IQueryable<Item> GetAll()
        {
            using (var context = new ApplicationContext())
            {
                var items = context.Items
                    .Include(i => i.City)
                    .Include(i => i.Condition)
                    .Include(i => i.Region)
                    .Include(i => i.Category)
                    .Include(i => i.Image);
                return items;
            }
        }

        public Item GetById(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Items.Where(p => p.ItemID == id)
                    .Include(i => i.City)
                    .Include(i => i.Condition)
                    .Include(i => i.Region)
                    .Include(i => i.Category)
                    .Include(i => i.Image)
                    .FirstOrDefault();
                return item;
            }
        }

        public IQueryable<Item> Search(string freeText)
        {
            using (var context = new ApplicationContext())
            {
                var items = context.Items.Where(p => p.Category.CategoryName.Contains(freeText) || 
                                                     p.City.CityName.Contains(freeText) || 
                                                     p.Condition.Status.Contains(freeText) ||
                                                     p.Region.RegionName.Contains(freeText) ||
                                                     p.Title.Contains(freeText) ||
                                                     p.Description.Contains(freeText))
                    .Include(i => i.City)
                    .Include(i => i.Condition)
                    .Include(i => i.Region)
                    .Include(i => i.Category)
                    .Include(i => i.Image);
                return items;
            }
        }

        //Region or Category
        public IQueryable<Item> FilteredSearch(Item Searchable)
        {
            using (var context = new ApplicationContext())
            {
                //var items = context.Items.Where(p => p.Category.CategoryName.Contains(searchTerm))
                var items = context.Items.Where(p => p.Region.RegionName.Contains(Searchable.Region.RegionName))
                    .Include(i => i.City)
                    .Include(i => i.Condition)
                    .Include(i => i.Region)
                    .Include(i => i.Category)
                    .Include(i => i.Image);
                return items;
            }
        }
    }
}
