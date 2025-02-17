using BelediyeCore.Utilities.Results;
using BelediyeEntities.Concrete.AbbUlasim;

namespace BelediyeBusiness.Abstract.AbbUlasim;

public interface IStopService
{
        IDataResult<List<Stop>> GetListStop(bool IsDeleted);

}
