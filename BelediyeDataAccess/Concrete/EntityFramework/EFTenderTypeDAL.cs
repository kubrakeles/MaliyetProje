using BelediyeCore.DataAccess.EntityFramework;
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
    public class EFTenderTypeDAL: EFEntityRepositoryBase<TenderType, TenderContext>, ITenderTypeDAL
    {
       
    }
}
