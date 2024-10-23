using BelediyeCore.Specification;
using BelediyeCore.Utilities.Results;
using BelediyeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeBusiness.Abstract
{
    public interface ITenderService
    {
        IList<Tender> GetList();
        IDataResult<List<Tender>> GetListByTenderType(int TypeID);
        IResult Add(Tender tender);
        IResult Update(Tender tender);
        IResult Delete(Tender tender);
        IDataResult<Tender> GetById(int Id); //Data Dönülecek
        IDataResult<List<Tender>> GetListByUnitType(int UnitID);
        Task<IReadOnlyList<Tender>> GetAllWithSpec();

    }
}
