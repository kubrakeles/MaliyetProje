using MaliyetCore.DataAccess;
using MaliyetEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetDataAccess.Abstract
{
    public  interface IUserDAL:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
   

    }
}
