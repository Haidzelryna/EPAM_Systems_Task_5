using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using BLL.Services;
using BLL;
using DAL;

namespace Task5
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var unityContainer = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //unityContainer.RegisterSingleton<IService<BLL.Contact>, ContactService>();
            //unityContainer.RegisterSingleton<IService<BLL.Client>, ClientService>();
            //unityContainer.RegisterSingleton<IService<BLL.Manager>, ManagerService>();
            //unityContainer.RegisterSingleton<IService<BLL.Product>, ProductService>();
            //unityContainer.RegisterSingleton<IService<BLL.Sale>, SaleService>();

            unityContainer.RegisterType<IService<BLL.Contact>, ContactService>();
            unityContainer.RegisterType<IService<BLL.Client>, ClientService>();
            unityContainer.RegisterType<IService<BLL.Manager>, ManagerService>();
            unityContainer.RegisterType<IService<BLL.Product>, ProductService>();
            unityContainer.RegisterType<IService<BLL.Sale>, SaleService>();

            unityContainer.RegisterInstance<SalesEntities>(new SalesEntities());

            DependencyResolver.SetResolver(new UnityDependencyResolver(unityContainer));
        }
    }
}