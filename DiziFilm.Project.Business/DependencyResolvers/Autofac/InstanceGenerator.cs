using Autofac;

namespace DiziFilm.Project.Business.DependencyResolvers.Autofac
{
   public class InstanceGenerator
    {
        public static T GetInstance<T>()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<BusinessModule>();

            return containerBuilder.Build().Resolve<T>();
        }
    }
}
