using System;
using System.Linq;
using System.Reflection;
using DiziFilm.Core.Aspects.Autofac.Exception;
using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DiziFilm.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector:IInterceptorSelector
    {
        public Castle.DynamicProxy.IInterceptor[] SelectInterceptors(Type type, MethodInfo method, Castle.DynamicProxy.IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect());

            return (Castle.DynamicProxy.IInterceptor[])classAttributes.ToArray();
        }
    }
}
