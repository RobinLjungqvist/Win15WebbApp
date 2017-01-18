using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebbApp.Mockup.Interfaces;
using WebbApp.Mockup.Models;

namespace WebbApp.Mockup.Repo
{
    public class MockupUserRepo : IUserRepository
    {
        public void CreateOrUpdateUser(MockupUser user)
        {
            throw new NotImplementedException();
        }

        public List<MockupUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public MockupUser GetUserByID(Guid id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}