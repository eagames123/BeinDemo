using DiziFilm.Core.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;

namespace DiziFilm.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        private IHostingEnvironment _hostingEnvironment;

        public ValidatorTool(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void FluentValidate(IValidator validator, object entity)
        {

            var result = validator.Validate(entity);

            if (result.Errors.Count > 0)
            {
                foreach (var error in result.Errors)
                {
                    LogBeinHelper logHelper = new LogBeinHelper(_hostingEnvironment);

                    logHelper.Insert("validate : " + error.ErrorMessage, Layer.Admin);
                }
            }
        }
    }
}
