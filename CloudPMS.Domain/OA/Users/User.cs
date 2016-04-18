using CloudPMS.Infrastructure;
using ENode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPMS.Domain.OA.Users
{
  public class User : AggregateRoot<string>
    {
        private string _userName;
        public User(string id, string userName)
            : base(id)
        {
            ApplyEvent(new UserCreatedEvent(userName));

        }
        private void Handle(UserCreatedEvent evnt)
        {
            _userName = evnt.UserName;
        }
        public void Update(string userName)
        {
            ApplyEvent(new UserUpdatedEvent(userName));
        }
        private void Handle(UserUpdatedEvent evnt)
        {
            _userName = evnt.UserName;
        }
    }
}
