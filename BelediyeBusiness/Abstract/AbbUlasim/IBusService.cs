using BelediyeCore.Utilities.Results;
using BelediyeEntities.Concrete.AbbUlasim;

namespace BelediyeBusiness.Abstract.AbbUlasim;

public interface IBusService
{
          IDataResult<List<Bus>> GetListBusActive(bool Active);
          

}
