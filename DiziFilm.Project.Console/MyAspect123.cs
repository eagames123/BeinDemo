using System;
using System.Collections.Generic;
using System.Text;
using PostSharp.Aspects;

namespace DiziFilm.Project.Console
{
    [Serializable]
    public class MyAspect123:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            System.Console.WriteLine("girdi");
        }
    }
}
