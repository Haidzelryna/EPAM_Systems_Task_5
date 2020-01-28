using AutoMapper;
using Unity;
using DAL.Repository;

namespace DAL
{
    public static class Facade
    {
        public static void SetupMapping(IMapperConfigurationExpression mapperConfiguration)
        {
 
        }

        public static void SetupDependencies(IUnityContainer unityContainer)
        {
            unityContainer.RegisterInstance<SalesEntities>(new SalesEntities());
            unityContainer.RegisterInstance<IGenericRepository<Contact>>(unityContainer.Resolve<SalesEntities>().ContactRepository);
            unityContainer.RegisterInstance<IGenericRepository<Client>>(unityContainer.Resolve<SalesEntities>().ClientRepository);
            unityContainer.RegisterInstance<IGenericRepository<Manager>>(unityContainer.Resolve<SalesEntities>().ManagerRepository);
            unityContainer.RegisterInstance<IGenericRepository<Product>>(unityContainer.Resolve<SalesEntities>().ProductRepository);
            unityContainer.RegisterInstance<IGenericRepository<Sale>>(unityContainer.Resolve<SalesEntities>().SaleRepository);
        }
    }
}