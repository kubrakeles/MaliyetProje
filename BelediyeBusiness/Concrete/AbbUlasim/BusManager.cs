using BelediyeBusiness.Abstract.AbbUlasim;
using BelediyeCore.Utilities.Messages;
using BelediyeCore.Utilities.Results;
using BelediyeDataAccess.Abstract.AbbUlasim;
using BelediyeEntities.Concrete.AbbUlasim;

namespace BelediyeBusiness.Concrete.AbbUlasim
{
    public class BusManager : IBusService
    {
     IBusDAL _busDAL;
     public BusManager(IBusDAL busDAL)
     {
        _busDAL=busDAL;
     } 
        public IDataResult<List<Bus>> GetListBusActive(bool Active)
        {
            var result = _busDAL.GetList(p => p.Active == Active);
                if (result == null || !result.Any())
                {
                    return new ErrorDataResult<List<Bus>>("Aktif otobüs bulunamadı.");
                }
                return new SuccessDataResult<List<Bus>>(result.ToList());
        }

    }
}