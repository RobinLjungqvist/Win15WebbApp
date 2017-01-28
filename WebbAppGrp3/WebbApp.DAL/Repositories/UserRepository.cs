using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL.Interfaces;

namespace WebbApp.DAL.Repositories
{
    public class UserRepository : IRepository<ApplicationUser>
    {
        //TODO: kontroll
        public void Add(ApplicationUser entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Users.Add(entity);
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
                var user = context.Users.Where<ApplicationUser>(p => p.Id == id.ToString()).FirstOrDefault();
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Delete(ApplicationUser entity)
        {
            return Delete(new Guid(entity.Id));
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            var list = new List<ApplicationUser>();
            using (var context = new ApplicationContext())
            {
                list = context.Users.Select(u => u).ToList();
            }
            return list.AsQueryable();
        }

        public ApplicationUser GetById(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var user = context.Users.Where(p => p.Id == id.ToString()).FirstOrDefault();
                return user;
            }
        }

        public void Update(ApplicationUser entity)
        {
            using (var context = new ApplicationContext())
            {
                var user = context.Users.Where(p => p.Id == entity.Id).FirstOrDefault();
                if (user != null)
                {
                    user.FirstName = entity.FirstName;
                    user.LastName = entity.LastName;
                    user.Email = entity.Email;
                    user.Password = entity.Password;
                    user.UserName = entity.UserName;
                    user.IsAdmin = entity.IsAdmin;
                    user.UserRole = entity.UserRole;
                    user.Region = entity.Region;
                    user.City = entity.City;
                    context.SaveChanges();
                }
            }
        }
    }
}
