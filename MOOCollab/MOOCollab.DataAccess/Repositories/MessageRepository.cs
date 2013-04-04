using System.Collections.Generic;
using System.Data;
using System.Linq;
using MOOCollab.Contracts;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.Domain;
namespace MOOCollab.DataAccess.Repositories
{
    public class MessageRepository : Repository<UserMessage>, IMessageRepository
    {
        /// <summary>
        /// Calls to base Repository in order to ensure all repositories use 
        /// the correct unit of work.
        /// DbContext is reachable through the Context property.
        /// 
        /// DbSet is reachable through the Set property.
        /// </summary>
        /// <param name="uow">
        /// Implemetation of IUow of T injected using ninject
        /// </param>
        public MessageRepository(IUow uow)
            : base(uow)
        {
        }

        public Message GetMessageById(int id)
        {
            return Set.FirstOrDefault(m => m.Id == id);
        }

        public IList<UserMessage> GetMessagesForUser(User user)
        {
            List<int> following = user.Following.Select(e => e.Id).ToList();
            return Set.Where(e => following.Contains(e.SenderId)).ToList();
        }

        public override void Create(UserMessage obj)
        {
            base.Create(obj);
        }

        /// <summary>
        /// Void a message. Does not delete.
        /// </summary>
        /// <param name="id">Message Id</param>
        public override void Delete(int id)
        {
            var messageToClose = Set.FirstOrDefault(c => c.Id == id);

            if (messageToClose != null)
            {
                //Mark as void
                messageToClose.DeleteMessage();

                Context.Entry(messageToClose).State = EntityState.Modified;
            }
        }

        public override void Delete(UserMessage obj)
        {
            var messageToClose = Set.FirstOrDefault(c => c.Id == obj.Id);

            if (messageToClose != null)
            {
                //Mark as void
                messageToClose.DeleteMessage();

                Context.Entry(messageToClose).State = EntityState.Modified;
            }
        }

        public override void Update(UserMessage obj)
        {

            var current = Set.Local.FirstOrDefault(c => c.Id == obj.Id);
            if (current != null)
            {
                Context.Entry(current).CurrentValues.SetValues(obj);
            }
            else
            {
                base.Update(obj);
            }

        }
    }
}