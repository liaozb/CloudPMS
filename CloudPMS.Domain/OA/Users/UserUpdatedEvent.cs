using ENode.Eventing;

namespace CloudPMS.Domain.OA.Users
{
    public class UserUpdatedEvent : DomainEvent<string>
    {
        public string UserName { get; private set; }
        private UserUpdatedEvent() { }
        public UserUpdatedEvent(string userName)
        {
            UserName = userName;
        }
    }
}