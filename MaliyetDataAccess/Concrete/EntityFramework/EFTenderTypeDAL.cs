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
    public class EFTenderTypeDAL: EFEntityRepositoryBase<TenderType, TenderContext>, ITenderTypeDAL
    {
       
    }
}
