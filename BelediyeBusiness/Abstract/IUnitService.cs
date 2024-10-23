using BelediyeCore.Utilities.Results;
using BelediyeEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeBusiness.Abstract
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
