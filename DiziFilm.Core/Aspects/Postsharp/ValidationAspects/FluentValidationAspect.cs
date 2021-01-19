using System;
using System.Linq;
using DiziFilm.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DiziFilm.Core.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using PostSharp.Aspects;

namespace DiziFilm.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private IHostingEnvironment _hostingEnvironment;

        public FluentValidationAspect(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool tool = new ValidatorTool(_hostingEnvironment);

                tool.FluentValidate(validator, entity);
            }

            LogBeinHelper logHelper = new LogBeinHelper(_hostingEnvironment);

            logHelper.Insert("onentry", Layer.Admin);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            LogBeinHelper logHelper = new LogBeinHelper(_hostingEnvironment);

            logHelper.Insert(args.Exception.Message, Layer.Admin);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            LogBeinHelper logHelper = new LogBeinHelper(_hostingEnvironment);

            logHelper.Insert("onentry", Layer.Admin);
        }

    }
}
