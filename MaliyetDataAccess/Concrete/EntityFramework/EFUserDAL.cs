using MaliyetCore.DataAccess.EntityFramework;
using MaliyetDataAccess.Abstract;
using MaliyetDataAccess.Concrete.EntityFramework.Contexts;
using MaliyetEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetDataAccess.Concrete.EntityFramework
{
    public class EFUserDAL : EFEntityRepositoryBase<User, TenderContext>, IUserDAL
    {
        private readonly TenderContext _tenderContext;
        public EFUserDAL(TenderContext tenderContext)
        {
            _tenderContext = tenderContext;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = _tenderContext)
            {
                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };

                return result.ToList();

            }
        }
    }
}
