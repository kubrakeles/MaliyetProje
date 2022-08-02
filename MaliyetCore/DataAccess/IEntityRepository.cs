using MaliyetCore.Entities;
using System.Linq.Expressions;

namespace MaliyetCore.DataAccess
    {
public interface IEntityRepository<T> where T: class, IEntity
{
 T Get(Expression<Func<T,bool>> filter);
 IList<T> GetList(Expression<Func<T,bool>> filter=null);
 void Add (T entity);
 void Update (T Entity);
 void Delete (T Entity);


}
}
