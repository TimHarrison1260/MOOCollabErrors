using System.Collections.Generic;
using MOOCollab.Domain;

namespace MOOCollab.Contracts.RepositoryContracts
{
    public interface IMessageRepository:IRepository<UserMessage>
    {
        IList<UserMessage> GetMessagesForUser(User user);
        void Delete(int id);
        void Delete(UserMessage obj);
        void Create(UserMessage obj);
        void Update(UserMessage obj);
    }
}