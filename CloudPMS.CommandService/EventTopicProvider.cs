using CloudPMS.Domain.OA.Users;
using ECommon.Components;
using ENode.EQueue;
using ENode.Eventing;

namespace CloudPMS.CommandService
{
    [Component]
    public class EventTopicProvider : AbstractTopicProvider<IDomainEvent>
    {
        public EventTopicProvider()
        {
           
           RegisterTopic("UserEventTopic", typeof(UserCreatedEvent));
          
        }
    }
}
