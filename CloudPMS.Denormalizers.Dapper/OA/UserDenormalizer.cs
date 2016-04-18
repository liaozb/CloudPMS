using ENode.Infrastructure;
using System.Threading.Tasks;
using ECommon.IO;
using CloudPMS.Domain.OA.Users;
using ECommon.Dapper;
using CloudPMS.Infrastructure;

namespace CloudPMS.Denormalizers.Dapper.OA
{
    public class UserDenormalizer : AbstractDenormalizer,
         IMessageHandler<UserCreatedEvent>,
         IMessageHandler<UserUpdatedEvent>
    {
        public Task<AsyncTaskResult> HandleAsync(UserUpdatedEvent evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    UserName = evnt.UserName,
                    UpdatedOn = evnt.Timestamp,
                    Version = evnt.Version
                }, new
                {
                    Id = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, Constants.UserTable);
            });
        }

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
