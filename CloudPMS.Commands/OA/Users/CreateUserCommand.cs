using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPMS.Commands.OA.Users
{
  public  class CreateUserCommand : Command
    {
        public string UserName { get; private set; }
      

        private CreateUserCommand() { }
        public CreateUserCommand(string id, string userName) : base(id)
        {
            UserName = userName;
          
        }
    }
}
