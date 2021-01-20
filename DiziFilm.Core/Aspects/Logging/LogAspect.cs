using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using DiziFilm.Core.Utilities;
using DiziFilm.Core.Utilities.Interceptors;

namespace DiziFilm.Core.Aspects.Autofac.Logging
{
    public class LogAspect:MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
            var logParameters = new List<string>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(
                    "Name : " + invocation.GetConcreteMethod().GetParameters()[i].Name +
                    "Value : " + invocation.Arguments[i] +
                    "Type : " + invocation.Arguments[i].GetType().Name
                );
            }

            LogBeinHelper helper = new LogBeinHelper(null);
            helper.Insert(String.Join(", ", logParameters.ToArray()), Layer.Admin);
        }

    }
}
