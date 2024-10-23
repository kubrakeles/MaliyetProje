using BelediyeCore.Specification;
using BelediyeCore.Utilities.Results;
using BelediyeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeBusiness.Abstract
{
    public interface INotificationService
    {
        IList<Notification> GetList();
        IResult Add(Notification Notification);
        IResult Update(Notification Notification);
        IResult Delete(Notification Notification);
        IDataResult<Notification> GetById(int Id); //Data Dönülecek
       // Task<IReadOnlyList<Notification>> GetAllWithSpec();

    }
}
