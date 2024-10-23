using BelediyeCore.DataAccess;
using BelediyeCore.Entities.Concrete;
using BelediyeEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeDataAccess.Abstract
{
    public  interface IUserDAL:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);

    }
}
