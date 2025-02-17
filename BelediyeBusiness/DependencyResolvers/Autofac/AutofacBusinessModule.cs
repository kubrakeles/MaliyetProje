using Autofac;
using BelediyeBusiness.Concrete;
using BelediyeBusiness.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelediyeDataAccess.Concrete.EntityFramework;
using BelediyeDataAccess.Abstract;
using BelediyeCore.Utilities.Security.Jwt;

namespace BelediyeBusiness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TenderManager>().As<ITenderService>();

            builder.RegisterType<EFTenderDAL>().As<ITenderDAL>();

            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<EFUserDAL>().As<IUserDAL>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<TenderTypeManager>().As<ITenderTypeService>();

            builder.RegisterType<EFTenderTypeDAL>().As<ITenderTypeDAL>();

            builder.RegisterType<UnitManager>().As<IUnitService>();

            builder.RegisterType<EFUnitDAL>().As<IUnitDAL>(); 

            builder.RegisterType<NotificationManager>().As<INotificationService>();
    
            builder.RegisterType<EFNotificationDAL>().As<INotificationDAL>();

        


        }
    }
}
