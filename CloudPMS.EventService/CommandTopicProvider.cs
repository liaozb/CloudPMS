using ECommon.Components;
using ENode.Commanding;
using ENode.EQueue;

namespace Forum.EventService.Providers
{
    [Component]
    public class CommandTopicProvider : AbstractTopicProvider<ICommand>
    {
        public CommandTopicProvider()
        {
           // RegisterTopic("PostCommandTopic", typeof(AcceptNewReplyCommand));
        }
    }
}
