using CloudPMS.Commands.OA.Users;
using ECommon.Components;
using ENode.Commanding;
using ENode.EQueue;

namespace CloudPMS.Web.Providers
{
    [Component]
    public class CommandTopicProvider : AbstractTopicProvider<ICommand>
    {
        public CommandTopicProvider()
        {
           
            RegisterTopic("UserCommandTopic", typeof(CreateUserCommand));
           
        }
    }
}