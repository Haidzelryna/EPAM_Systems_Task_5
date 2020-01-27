using AutoMapper;
using Unity;
using BLL.Services;

namespace BLL
{
    public static class Facade
    {
        public static void SetupMapping(IMapperConfigurationExpression mapperCfg)
        {
            DAL.Facade.SetupMapping(mapperCfg);
        }

        public static void SetupDependencies(IUnityContainer unityContainer)
        {
            DAL.Facade.SetupDependencies(unityContainer);

            unityContainer.RegisterSingleton<IService<Contact>, ContactService>();
            unityContainer.RegisterSingleton<IService<Client>, ClientService>();
            unityContainer.RegisterSingleton<IService<Manager>, ManagerService>();
            unityContainer.RegisterSingleton<IService<Product>, ProductService>();
            unityContainer.RegisterSingleton<IService<Sale>, SaleService>();
        }
    }
}
