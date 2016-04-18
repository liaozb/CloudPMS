using ENode.Eventing;

namespace CloudPMS.Domain.OA.Users
{
    public  class UserCreatedEvent : DomainEvent<string>
    {
        public string UserName { get; private set; }
        private UserCreatedEvent() { }
        public UserCreatedEvent(string userName)
        {
            UserName = userName;
        }
    }
}
