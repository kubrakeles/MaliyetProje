using MaliyetCore.Utilities.Results;
using MaliyetEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetBusiness.Abstract
{
    public interface IUnitService
    {
        IList<Unit> GetList();
        Unit Get(int id);
        IResult Add(Unit unitID);
        IResult Update(Unit unitID);
        IResult Delete(Unit unitID);
    }
}
