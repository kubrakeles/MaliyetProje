using BelediyeCore.DataAccess.EntityFramework;
using BelediyeDataAccess.Abstract.AbbUlasim;
using BelediyeDataAccess.Concrete.EntityFramework.Contexts;
using BelediyeEntities.Concrete.AbbUlasim;

namespace BelediyeDataAccess.Concrete.EntityFramework.AbbUlasim;

public class EFAttentionDAL : EFEntityRepositoryBase<Attention,UlasimContext>,IAttentionDAL
{
}
