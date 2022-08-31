using MaliyetBusiness.Abstract;
using MaliyetCore.Utilities.Results;
using MaliyetDataAccess.Abstract;
using MaliyetDataAccess.Concrete.EntityFramework;
using MaliyetDataAccess.Data;
using MaliyetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetBusiness.Concrete
{
    public class TenderManager : ITenderService
    {
        ITenderDAL _tenderDAL;
        public TenderManager(ITenderDAL tenderDAL)
        {
            _tenderDAL = tenderDAL; 
        }
        public IResult Add(Tender tender)
        {
            _tenderDAL.Add(tender);
          return new SuccessResult("İhale Başarı ile Eklendi.");
        }

        public IResult Delete(Tender tender)
        {
            _tenderDAL.Delete(tender);
            return new SuccessResult("İhale Başarı ile Silindi.");
        }

        public async Task< IReadOnlyList<Tender>> GetAllWithSpec()
        {
            var spec = new TendersWithTenderTypeSpec();

            return await _tenderDAL.GetListWithSpec(spec);
        }

        public IDataResult<Tender> GetById(int Id)
        {
            return new SuccessDataResult<Tender>( _tenderDAL.Get(filter: p => p.Id == Id));
        }

        public IList<Tender> GetList()
        {
            return _tenderDAL.GetList().ToList();
        }

        public IDataResult<List<Tender>> GetListByTenderType(int TypeID)
        {
            return new SuccessDataResult<List<Tender>>( _tenderDAL.GetList(filter: p => p.TenderTypeId == TypeID).ToList());
        }

        public IDataResult< List<Tender>> GetListByUnitType(int UnitID)
        {
            return new SuccessDataResult<List<Tender>>( _tenderDAL.GetList(filter:p=>p.UnitId==UnitID).ToList());
        }

        public IResult Update(Tender tender)
        {
            _tenderDAL.Update(tender);
            return new SuccessResult("İhale Başarı ile Güncellendi");
        }

    }
}
