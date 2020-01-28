using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using AutoMapper;
using Task5.Controllers;
using Unity.Injection;

namespace Task5
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            //container.RegisterType<UsersAdminController>(new InjectionConstructor());

            container.RegisterInstance(SetupMapper());

            BLL.Facade.SetupDependencies(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static IMapper SetupMapper()
        {
            var config = new MapperConfiguration(mapperCfg =>
            {
                BLL.Facade.SetupMapping(mapperCfg);

                mapperCfg.CreateMap<BLL.Sale, Task5.Sale>();
                mapperCfg.CreateMap<BLL.Contact, Task5.Contact>();
                mapperCfg.CreateMap<BLL.Manager, Task5.Manager>();
                mapperCfg.CreateMap<BLL.Client, Task5.Client>();
                mapperCfg.CreateMap<BLL.Product, Task5.Product>();

                mapperCfg.CreateMap<Task5.Sale, BLL.Sale>();
                mapperCfg.CreateMap<Task5.Contact, BLL.Contact>();
                mapperCfg.CreateMap<Task5.Manager, BLL.Manager>();
                mapperCfg.CreateMap<Task5.Client, BLL.Client>();
                mapperCfg.CreateMap<Task5.Product, BLL.Product>();
            });

            return config.CreateMapper();
        }
    }
}