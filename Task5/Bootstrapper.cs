using Unity;
using AutoMapper;

namespace Task5
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here  
            //This is the important line to edit  
            //container.RegisterType<ICompanyRepository, CompanyRepository>();


            //RegisterTypes(container);

            ConfigureContainer();

            return container;
        }
        //public static void RegisterTypes(IUnityContainer container)
        //{

        //}

        public static void ConfigureContainer()//(IUnityContainer container)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterInstance(SetupMapper());

            BLL.Facade.SetupDependencies(container);
        }

        private static IMapper SetupMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                BLL.Facade.SetupMapping(cfg);
            });

            return new Mapper(config);
        }
    }
}