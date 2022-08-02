using MaliyetCore.Utilities.Results;
using MaliyetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetBusiness.Abstract
{
    public interface ITenderService
    {
        IDataResult<List<Tender>> GetList();
        IDataResult<List<Tender>> GetListByTenderType(int TypeID);
        IResult Add(Tender tender);
        IResult Update(Tender tender);
        IResult Delete(Tender tender);
        IDataResult<Tender> GetById(int Id); //Data Dönülecek
      IDataResult<List<Tender>> GetListByUnitType(int UnitID);

    }
}
