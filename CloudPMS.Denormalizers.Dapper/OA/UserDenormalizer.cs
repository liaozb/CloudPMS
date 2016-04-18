using ENode.Infrastructure;
using System;
using System.Threading.Tasks;
using ECommon.IO;
using CloudPMS.Domain.OA.Users;
using ECommon.Dapper;
using CloudPMS.Infrastructure;

namespace CloudPMS.Denormalizers.Dapper.OA
{
    public class UserDenormalizer : AbstractDenormalizer,
         IMessageHandler<UserCreatedEvent>
    {
        public Task<AsyncTaskResult> HandleAsync(UserCreatedEvent evnt)
        {
            return TryInsertRecordAsync(connection =>
            {
                return connection.InsertAsync(new
                {
                    Id = evnt.AggregateRootId,
                    UserName = evnt.UserName,
                    CreatedOn = evnt.Timestamp,
                    UpdatedOn = evnt.Timestamp,
                    Version = evnt.Version
                }, Constants.UserTable);
            });
        }
    }
}
