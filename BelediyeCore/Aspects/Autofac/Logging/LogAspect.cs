//using Castle.Core.Interceptor;
//using BelediyeCore.CrossCuttingConcerns.Logging;
//using BelediyeCore.CrossCuttingConcerns.Logging.Log4Net;
//using BelediyeCore.Utilities.Interceptors;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BelediyeCore.Aspects.Autofac.Logging
//{
//    public class LogAspect:MethodInterception
//    {
//        private LoggerServiceBase _loggerServiceBase;

//        public LogAspect(Type loggerService)
//        {
//            if(loggerService.BaseType!=typeof(LoggerServiceBase))
//            {
//                throw new Exception(message: "Wrong Logger Type!");

//            }
//            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
//        }
//        //protected override void OnBefore(IInvocation invocation)
//        //{
//        //    _loggerServiceBase.Info(GetLogDetail(invocation));
//        //}
//        //private LogDetail GetLogDetail(IInvocation invocation)
//        //{
//        //    var logParameters = new List<LogParameter>();
//        //    for (int i = 0; i < invocation.Arguments.Length; i++)
//        //    {
//        //        logParameters.Add(new LogParameter
//        //        {
//        //            Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
//        //            Value = invocation.Arguments[i].ToString(),
//        //            Type = invocation.Arguments[i].GetType().Name
//        //        });
//        //    }

//        //    var LogDetails = new LogDetail {
                
//        //        LogParameters=logParameters,
//        //        MethodName=invocation.Method.Name
//        //    };
//        //    return LogDetails;
//        //}
//    }
//}
