using BelediyeBusiness.Abstract;
//using BelediyeCore.Aspects.Autofac.Logging;
using BelediyeCore.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using BelediyeCore.Utilities.Results;
using BelediyeDataAccess.Abstract;
using BelediyeDataAccess.Concrete.EntityFramework;
using BelediyeDataAccess.Data;
using BelediyeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeBusiness.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDAL _NotificationDAL;
        public NotificationManager(INotificationDAL NotificationDAL)
        {
            _NotificationDAL = NotificationDAL; 
        }
       
        public IResult Add(Notification Notification)
        {
            _NotificationDAL.Add(Notification);
          return new SuccessResult("Bildirim Eklendi.");
        }

        public IResult Delete(Notification Notification)
        {
            _NotificationDAL.Delete(Notification);
            return new SuccessResult("Bildirim Silindi.");
        }

   
        public IDataResult<Notification> GetById(int Id)
        {
            return new SuccessDataResult<Notification>( _NotificationDAL.Get(filter: p => p.Id == Id));
        }
        //[LogAspect(typeof(DatabaseLogger))]
        public IList<Notification> GetList()
        {
            return _NotificationDAL.GetList().ToList();
        }

 

   
        public IResult Update(Notification Notification)
        {
            _NotificationDAL.Update(Notification);
            return new SuccessResult("Bildirim Başarı ile Güncellendi");
        }

    }
}
