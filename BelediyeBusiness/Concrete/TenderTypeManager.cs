﻿using BelediyeBusiness.Abstract;
using BelediyeCore.Utilities.Results;
using BelediyeDataAccess.Abstract;
using BelediyeEntities;
using BelediyeEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeBusiness.Concrete
{
    public class TenderTypeManager : ITenderTypeService
    {
        ITenderTypeDAL _tenderTypeDAL;
        public TenderTypeManager(ITenderTypeDAL tenderTypeDAL)
        {
            this._tenderTypeDAL = tenderTypeDAL;
        }

        public IResult Add(TenderType tenderType)
        {
            _tenderTypeDAL.Add(tenderType);
            return new SuccessResult("İhale Türü Başarı ile Eklendi.");
        }

        public IResult Delete(TenderType tenderType)
        {
            _tenderTypeDAL.Delete(tenderType);
            return new SuccessResult("İhale Türü Silindi");
        }

        public TenderType Get(int id)
        {
            return _tenderTypeDAL.Get(filter: p => p.Id == id);
        }

        public IList<TenderType> GetList()
        {
          
            return _tenderTypeDAL.GetList();
        }

        //public Unit GetUnit(int unitId)
        //{
        //    return _tenderTypeDAL.GetUnitById(filter:p=>p.id == unitId);
        //}

        //public IList<Unit> GetUnits()
        //{
        //    return _tenderTypeDAL.GetUnits();
        //}

        public IResult Update(TenderType tenderType)
        {
            _tenderTypeDAL.Update(tenderType);
            return new SuccessResult("İhale Türü Güncellendi");
        }
        
    }
}
