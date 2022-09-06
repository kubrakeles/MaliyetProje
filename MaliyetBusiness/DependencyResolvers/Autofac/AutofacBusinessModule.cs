using Autofac;
using MaliyetBusiness.Concrete;
using MaliyetBusiness.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaliyetDataAccess.Concrete.EntityFramework;
using MaliyetDataAccess.Abstract;
using MaliyetCore.Utilities.Security.Jwt;

namespace MaliyetBusiness.DependencyResolvers.Autofac
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


        }
    }
}
