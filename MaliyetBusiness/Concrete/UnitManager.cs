using MaliyetBusiness.Abstract;
using MaliyetCore.Utilities.Results;
using MaliyetDataAccess.Abstract;
using MaliyetEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetBusiness.Concrete
{
    public class UnitManager : IUnitService
    {
        IUnitDAL _unitDAL;
        public UnitManager( IUnitDAL unitDAL )
        {
            _unitDAL = unitDAL;
        }
        public IResult Add(Unit unit)
        {
            _unitDAL.Add(unit);
            return new SuccessResult("İhale Türü Başarı ile Eklendi.");
        }

        public IResult Delete(Unit unit)
        {
            _unitDAL.Delete(unit);
            return new SuccessResult("İhale Türü Silindi");
        }

        public Unit Get(int id)
        {
            return _unitDAL.Get(filter: p => p.id == id);
        }

        public IList<Unit> GetList()
        {
            return _unitDAL.GetList();
        }

        public IResult Update(Unit unit)
        {
            _unitDAL.Update(unit);
            return new SuccessResult("İhale Türü Güncellendi");
        }
    }
}
