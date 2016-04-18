using System;
using CloudPMS.Commands.OA.Users;
using CloudPMS.Domain.OA.Users;
using ENode.Commanding;

namespace CloudPMS.CommandHandlers.OA
{
    public class UserCommandHandler : ICommandHandler<CreateUserCommand>, ICommandHandler<UpdateUserCommand>
    {
        public void Handle(ICommandContext context, UpdateUserCommand command)
        {
            context.Get<User>(command.AggregateRootId).Update(command.UserName);
        }

        public void Handle(ICommandContext context, CreateUserCommand command)
        {
            context.Add(new User(command.AggregateRootId, command.UserName));
        }
    }
}
