using BelediyeCore.DataAccess.EntityFramework;
using BelediyeDataAccess.Abstract;
using BelediyeDataAccess.Concrete.EntityFramework.Contexts;
using BelediyeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeDataAccess.Concrete.EntityFramework
{
    public class EFTenderDAL :EFEntityRepositoryBase<Tender,TenderContext>,ITenderDAL
    {
        
    }
}
