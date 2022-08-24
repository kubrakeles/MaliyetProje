using MaliyetCore.DataAccess.EntityFramework;
using MaliyetDataAccess.Abstract;
using MaliyetDataAccess.Concrete.EntityFramework.Contexts;
using MaliyetEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetDataAccess.Concrete.EntityFramework
{
    public class EFTenderTypeDAL: EFEntityRepositoryBase<TenderType, TenderContext>, ITenderTypeDAL
    {
        private readonly TenderContext _tenderContext;
        public EFTenderTypeDAL(TenderContext tenderContext)
        {
            _tenderContext = tenderContext;
        }
        //Birimler için ayrı bir Manager ve Service Eklemeden Direkt Dal üzerinden Eriştik
        public List<Unit> GetUnits()
        {
            using(var context = _tenderContext)
            {

                var units = context.Units.ToList();
                return units;
            }

        }

    }
}
