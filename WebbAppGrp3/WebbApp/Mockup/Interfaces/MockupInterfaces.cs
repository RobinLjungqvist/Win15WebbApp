using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebbApp.Mockup.Models;

namespace WebbApp.Mockup.Interfaces
{
    public interface IUserRepository
    {
        List<MockupUser> GetAllUsers();
        MockupUser GetUserByID(Guid id);
        void RemoveUserByID(Guid id);
        void CreateOrUpdateUser(MockupUser user);

    }

    public interface IItemRepository
    {
        List<MockupItem> GetAllItems();
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
        List<MockupConversation> GetConversationsByUserID(Guid id);
        MockupConversation GetConversationByID(Guid id);

        void RemoveConversationByID(Guid id);

        void CreateOrUpdateConversation(MockupConversation conversation);
    }

    public interface IRegionRepository
    {
        List<MockupRegion> GetAllRegions();

        MockupRegion GetRegionByID(Guid id);

        void RemoveRegionByID(Guid id);

        void CreateOrUpdateRegion(MockupRegion region);
    }

}