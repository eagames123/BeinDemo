using Autofac;
using DiziFilm.Project.Business.ValidationRules.FluentValidation;
using DiziFilm.Project.Entities.Concrete;
using FluentValidation;
using Module = Autofac.Module;

namespace DiziFilm.Project.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FilmValidator>().As<IValidator<Film>>().InstancePerDependency();
         
        }
    }
}
