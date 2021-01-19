using System;
using PostSharp.Aspects;

namespace DiziFilm.Core.Aspects.Postsharp
{
    [Serializable]
    public class ExceptionHandlingAspect : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            if (args.Exception != null)
            {
                throw args.Exception;
            }
        }
    }
}