using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbApp.DAL.Interfaces;
using WebbApp.DAL.DB.Models;

namespace WebbApp.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private ApplicationContext ctx;

        public CategoryRepository()
        {
            this.ctx = new ApplicationContext();
        }

        public void Add(Category entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Categories.Add(entity);
                context.SaveChanges();
            }
        }

        public void AddImage(Image entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
                if (item != null)
                {
                    context.Categories.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Delete(Category entity)
        {
            return Delete(entity.CategoryId);
        }

        public IQueryable<Category> GetAll()
        {
            var list = new List<Category>();
            using (var context = new ApplicationContext())
            {
                 list = context.Categories.ToList();
            }
            return list.AsQueryable();
        }

        public Category GetById(Guid id)
        {
            Category item;
            using (var context = new ApplicationContext())
            {
                item = context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            }
            return item;
        }

        public List<Item> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Categories.Where(c => c.CategoryId == entity.CategoryId).FirstOrDefault();
                if (item != null)
                {
                    item.CategoryName = entity.CategoryName;
                    context.SaveChanges();
                }
            }
        }
    }

    //*******************************************************************************

    public class CityRepository : IRepository<City>
    {
        private ApplicationContext ctx;

        public CityRepository()
        {
            this.ctx = new ApplicationContext();
        }

        public void Add(City entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Cities.Add(entity);
                context.SaveChanges();
            }
        }

        public void AddImage(Image entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Cities.Where(c => c.CityId == id).FirstOrDefault();
                if (item != null)
                {
                    context.Cities.Remove(item);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Delete(City entity)
        {
            return Delete(entity.CityId);
        }

        public IQueryable<City> GetAll()
        {
            var list = new List<City>();
            using (var context = new ApplicationContext())
            {
                list = context.Cities.ToList();
            }
            return list.AsQueryable();
        }

        public City GetById(Guid id)
        {
            City item;
            using (var context = new ApplicationContext())
            {
                item = context.Cities.Where(c => c.CityId == id).FirstOrDefault();
            }
            return item;
        }

        public List<Item> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(City entity)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Cities.Where(c => c.CityId == entity.CityId).FirstOrDefault();
                if (item != null)
                {
                    item.CityName = entity.CityName;
                    context.SaveChanges();
                }
            }
        }
    }

    //**********************************************************************

    public class RegionRepository : IRepository<Region>
    {
        private ApplicationContext ctx;

        public RegionRepository()
        {
            this.ctx = new ApplicationContext();
        }

        public void Add(Region entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Regions.Add(entity);
                context.SaveChanges();
            }
        }

        public void AddImage(Image entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Regions.Where(c => c.RegionId == id).FirstOrDefault();
                if (item != null)
                {
                    context.Regions.Remove(item);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Delete(Region entity)
        {
            return Delete(entity.RegionId);
        }

        public IQueryable<Region> GetAll()
        {
            var list = new List<Region>();
            using (var context = new ApplicationContext())
            {
                list = context.Regions.ToList();
            }
            return list.AsQueryable();
        }

        public Region GetById(Guid id)
        {
            Region item;
            using (var context = new ApplicationContext())
            {
                item = context.Regions.Where(r => r.RegionId == id).FirstOrDefault();
            }
            return item;
        }

        public List<Item> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Region entity)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Regions.Where(c => c.RegionId == entity.RegionId).FirstOrDefault();
                if (item != null)
                {
                    item.RegionName = entity.RegionName;
                    context.SaveChanges();
                }
            }
        }
    }

    //*********************************************************************

    public class ConditionRepository : IRepository<Condition>
    {
        private ApplicationContext ctx;

        public ConditionRepository()
        {
            this.ctx = new ApplicationContext();
        }

        public void Add(Condition entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Conditions.Add(entity);
                context.SaveChanges();
            }
        }

        public void AddImage(Image entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Conditions.Where(c => c.ConditionId == id).FirstOrDefault();
                if (item != null)
                {
                    context.Conditions.Remove(item);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Delete(Condition entity)
        {
            return Delete(entity.ConditionId);
        }

        public IQueryable<Condition> GetAll()
        {
            var list = new List<Condition>();
            using (var context = new ApplicationContext())
            {
                list = context.Conditions.ToList();
            }
            return list.AsQueryable();
        }

        public Condition GetById(Guid id)
        {
            Condition item;
            using (var context = new ApplicationContext())
            {
                item = context.Conditions.Where(c => c.ConditionId == id).FirstOrDefault();
            }
            return item;
        }

        public List<Item> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Condition entity)
        {
            using (var context = new ApplicationContext())
            {
                var item = context.Conditions.Where(c => c.ConditionId == entity.ConditionId).FirstOrDefault();
                if (item != null)
                {
                    item.Status = entity.Status;
                    context.SaveChanges();
                }
            }
        }
    }
}
