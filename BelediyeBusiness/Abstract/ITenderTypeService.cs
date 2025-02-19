﻿using BelediyeCore.Utilities.Results;
using BelediyeEntities;
using BelediyeEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeBusiness.Abstract
{
    public interface ITenderTypeService
    {
        IList<TenderType> GetList();
        TenderType Get(int id);
        IResult Add(TenderType tenderType);
        IResult Update(TenderType tenderType);
        IResult Delete(TenderType tenderType);

       // IList<Unit> GetUnits();
       //Unit GetUnit(int unitId);
      
    }
}
