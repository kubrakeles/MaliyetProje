﻿//using Castle.Core.Interceptor;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BelediyeCore.Utilities.Interceptors
//{
//    public abstract class MethodInterception:MethodInterceptionBaseAttribute
//    {
//        protected virtual void OnBefore(IInvocation invocation) { }
//        protected virtual void OnAfter(IInvocation invocation) { }
//        protected virtual void OnException(IInvocation invocation) { }
//        protected virtual void OnSuccess(IInvocation invocation) { }

//        public override void Intercept(IInvocation invocation)
//        {
//            var isSuccess = true;
//            OnBefore(invocation);
//            try
//            {
//                invocation.Proceed();
//            }
//            catch (Exception e)
//            {
//                isSuccess = false;
//                OnException(invocation);
//                throw;
//            }
//            finally
//            {
//                if(isSuccess)
//                {
//                    OnSuccess(invocation);
//                }
//            }
//            OnAfter(invocation);
//        }
//    }
//}
