using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebbApp.Mockup.Interfaces;
using WebbApp.Mockup.Models;

namespace WebbApp.Mockup.Repo
{
    public class MockupUserRepository : IUserRepository
    {
        static List<MockupUser> Users;

        public MockupUserRepository()
        {
            Users.Add(new MockupUser(Guid.NewGuid(), "Pelle", "Svanslös", "Pelle@email.com", "Pella", "password", false, "Helsingborg", "Skåne"));
            Users.Add(new MockupUser(Guid.NewGuid(), "Kalle", "Blomkvist", "Kalle@email.com", "KallePower", "password", false, "Stockholm", "Stockholm"));
            Users.Add(new MockupUser(Guid.NewGuid(), "Lisa", "Sävås", "Lisa@email.com", "Lisa", "password", false, "Göteborg", "Västra Götaland"));
            Users.Add(new MockupUser(Guid.NewGuid(), "Hanna", "Petersson", "Hanna@email.com", "Hannapy", "password", false, "Växjö", "Småland"));
        }
        public void CreateOrUpdateUser(MockupUser user)
        {
            Users.Add(user);
        }

        public List<MockupUser> GetAllUsers()
        {
            return Users;
        }

        public MockupUser GetUserByID(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.UserID == id);

            return user;
        }

        public MockupUser LoginUser(string Email, string password)
        {
            var user = new MockupUser();

            if (Email == "admin" && password == "password")
            {
                user.UserID = Guid.NewGuid();
            }
            return user;
        }

        public void RemoveUserByID(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.UserID == id);


            if(user != null)
            {
                Users.Remove(user);
            }
        }
    }
}