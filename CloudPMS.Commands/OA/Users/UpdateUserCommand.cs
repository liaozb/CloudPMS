using ENode.Commanding;

namespace CloudPMS.Commands.OA.Users
{
    public class UpdateUserCommand : Command
    {
        public string UserName { get; private set; }
        private UpdateUserCommand() { }
        public UpdateUserCommand(string id, string userName) : base(id)
        {
            UserName = userName;
        }
    }
}
