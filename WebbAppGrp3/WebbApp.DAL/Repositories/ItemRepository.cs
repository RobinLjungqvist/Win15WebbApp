using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL.Interfaces;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace WebbApp.DAL.Repositories
{
    public class ItemRepository : ISearchableRepository<Item>
    {
        private ApplicationContext ctx;

        public ItemRepository()
        {
            this.ctx = new ApplicationContext();
        }
        public void AddImage(Image entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Images.Add(entity);
                context.SaveChanges();
            }
        }


        public void Add(Item entity)
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    context.Items.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                
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
                    item.Images = entity.Images;
                    item.Description = entity.Description;
                    item.CreateDate = entity.CreateDate;
                    item.ExpirationDate = entity.ExpirationDate;
                    item.City = entity.City;
                    item.Condition = entity.Condition;
                    item.Category = entity.Category;
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
                    .Include(i => i.Images)
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
            var items = new List<Item>();
            using (var context = new ApplicationContext())
            {
                    items = context.Items
                    .Include(i => i.City)
                    .Include(i => i.Condition)
                    .Include(i => i.Region)
                    .Include(i => i.Category)
                    .Include(i => i.Images)
                    .ToList();
            }
            return items.AsQueryable();
        }

        public Item GetById(Guid id)
        {
            Item item; ;
            using (var context = new ApplicationContext())
            {
                item = context.Items.Where(p => p.ItemID == id)
                    .Include(i => i.City)
                    .Include(i => i.Condition)
                    .Include(i => i.Region)
                    .Include(i => i.Category)
                    .Include(i => i.Images)
                    .FirstOrDefault();
            }
            return item;
        }

        public IQueryable<Item> Search(string freeText)
        {
            var items = new List<Item>();
            using (var context = new ApplicationContext())
            {
                items = context.Items.Where(p => p.Category.CategoryName.Contains(freeText) ||
                                                     p.City.CityName.Contains(freeText) ||
                                                     p.Condition.Status.Contains(freeText) ||
                                                     p.Region.RegionName.Contains(freeText) ||
                                                     p.Title.Contains(freeText) ||
                                                     p.Description.Contains(freeText))
                    .Include(i => i.City)
                    .Include(i => i.Condition)
                    .Include(i => i.Region)
                    .Include(i => i.Category)
                    .Include(i => i.Images)
                    .ToList();
            }
            return items.AsQueryable();
        }

        //Region or Category - inparameter is an empty Item object except searchcriterium attribute is filled.
        public IQueryable<Item> FilteredSearch(Item searchable)
        {
            using (var context = new ApplicationContext())
            {
                var items = new List<Item>();
                if (searchable.Region != null)
                {
                    items = context.Items.Where(p => p.Region.RegionName.Contains(searchable.Region.RegionName))
                        .Include(i => i.City)
                        .Include(i => i.Condition)
                        .Include(i => i.Region)
                        .Include(i => i.Category)
                        .Include(i => i.Images)
                        .ToList();
                } else if (searchable.Category != null)
                {
                    items = context.Items.Where(p => p.Category.CategoryName.Contains(searchable.Category.CategoryName))
                        .Include(i => i.City)
                        .Include(i => i.Condition)
                        .Include(i => i.Region)
                        .Include(i => i.Category)
                        .Include(i => i.Images)
                        .ToList();
                }
                return items != null ? items.AsQueryable() : null;
            }
        }

       
    }
}
