using BelediyeCore.DataAccess;
using BelediyeEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeDataAccess.Abstract
{
    public interface IUnitDAL : IEntityRepository<Unit>
    {
    }
}
