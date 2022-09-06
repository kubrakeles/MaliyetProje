using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MaliyetCore.Specification;
using MaliyetEntities;
using MaliyetEntities.Concrete;

namespace MaliyetDataAccess.Data
{
    public class TendersWithTenderTypeSpec : BaseSpecification<Tender>
    {
        public TendersWithTenderTypeSpec()
        {
            AddInclude(x => x.TenderTypeId);
            //AddInclude(x => x.UnitId);
        }
        public TendersWithTenderTypeSpec(int id)
            :base(x=>x.Id==id)
        {
            AddInclude(x => x.TenderTypeId);
           // AddInclude(x => x.UnitId);
        }

    }
}
