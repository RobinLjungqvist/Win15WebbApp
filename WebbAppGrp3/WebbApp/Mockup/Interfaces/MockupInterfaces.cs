using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebbApp.Mockup.Models;

namespace WebbApp.Mockup.Interfaces
{
    public interface IUserRepository
    {
        MockupUser GetUserByID(Guid id);
        void RemoveUserByID(Guid id);
        void CreateOrUpdateUser(MockupUser user);

    }

    public interface IItemRepository
    {
        MockupItem GetItemByID(Guid id);

        void RemoveItemByID(Guid id);

        void CreateOrUpdateItem(MockupItem item);

        MockupItem GetItemByRegion(string Region); 
    }

    public interface IMessageRepository
    {
        MockupMessage GetMessageByID(Guid id);

        void RemoveMessageByID(Guid id);

        void CreateOrUpdateMessage(MockupMessage message);

    }

    public interface IConversationRepository
    {

    }
}