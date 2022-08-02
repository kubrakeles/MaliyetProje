using MaliyetCore.DataAccess.EntityFramework;
using MaliyetDataAccess.Abstract;
using MaliyetDataAccess.Concrete.EntityFramework.Contexts;
using MaliyetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetDataAccess.Concrete.EntityFramework
{
    public class EFTenderDAL :EFEntityRepositoryBase<Tender,TenderContext>,ITenderDAL
    {
        public async Task<Tender> GetUnitByID(int id)
        {


        }

    }
}
