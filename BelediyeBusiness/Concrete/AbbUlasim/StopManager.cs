using BelediyeBusiness.Abstract.AbbUlasim;
using BelediyeCore.Utilities.Results;
using BelediyeDataAccess.Abstract.AbbUlasim;
using BelediyeEntities.Concrete.AbbUlasim;

namespace BelediyeBusiness.Concrete.AbbUlasim;

public class StopManager : IStopService
{
    IStopDAL _stopDal;
    public StopManager(IStopDAL stopDal)
    {
        _stopDal=stopDal;   
    }
    public IDataResult<List<Stop>> GetListStop(bool IsDeleted)
    {
      var result = _stopDal.GetList(p => p.IsDeleted == IsDeleted);
                if (result == null || !result.Any())
                {
                    return new ErrorDataResult<List<Stop>>("Aktif otobüs bulunamadı.");
                }
                return new SuccessDataResult<List<Stop>>(result.ToList());
    }
}
