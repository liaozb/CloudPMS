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
            Assert.IsNotNullOrWhiteSpace("帖子标题", userName);
         
            if (userName.Length > 256)
            {
                throw new Exception("帖子标题长度不能超过256");
            }
          
            ApplyEvent(new UserCreatedEvent(userName));

        }
        private void Handle(UserCreatedEvent evnt)
        {
            _userName = evnt.UserName;
        }
    }
}
