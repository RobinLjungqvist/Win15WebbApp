using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL.Interfaces;

namespace WebbApp.DAL.Repositories
{
    class UserRepository : IRepository<ApplicationUser>
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

        public void Delete(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                context.Users.Remove(context.Users.Where<ApplicationUser>(p => p.Id == id.ToString()).FirstOrDefault());
                context.SaveChanges();
            }
        }

        public void Delete(ApplicationUser entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Users.Remove(context.Users.Where<ApplicationUser>(p => p.Id == entity.Id.ToString()).FirstOrDefault());
                context.SaveChanges();
            }
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            using (var context = new ApplicationContext())
            {
                return context.Users.Select(s => s);
            }
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
