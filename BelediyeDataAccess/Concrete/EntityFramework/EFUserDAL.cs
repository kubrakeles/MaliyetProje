using BelediyeCore.DataAccess.EntityFramework;
using BelediyeCore.Entities.Concrete;
using BelediyeDataAccess.Abstract;
using BelediyeDataAccess.Concrete.EntityFramework.Contexts;
using BelediyeEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeDataAccess.Concrete.EntityFramework
{
    public class EFUserDAL : EFEntityRepositoryBase<User, NotificationContext>, IUserDAL
    {
        private readonly NotificationContext _notificationContext;
        public EFUserDAL(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = _notificationContext)
            {
                var result = from OperationClaim in context.OperationClaim
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };

                return result.ToList();

            }
        }
    }
}
