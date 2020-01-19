using Microsoft.Owin;
using Owin;
using Unity;
using BLL;
using AutoMapper;

[assembly: OwinStartupAttribute(typeof(Task5.Startup))]
namespace Task5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            ConfigureContainer();
        }

        public void ConfigureContainer()//(IUnityContainer container)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterInstance(SetupMapper());

            DAL.Facade.SetupDependencies(container);
        }

        private IMapper SetupMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                DAL.Facade.SetupMapping(cfg);

                cfg.CreateMap<BLL.Sale, Sale>();
                cfg.CreateMap<BLL.Contact, Contact>();
                cfg.CreateMap<BLL.Manager, Manager>();
                cfg.CreateMap<BLL.Client, Client>();
                cfg.CreateMap<BLL.Product, Product>();

                cfg.CreateMap<Sale, BLL.Sale>();
                cfg.CreateMap<Contact, BLL.Contact>();
                cfg.CreateMap<Manager, BLL.Manager>();
                cfg.CreateMap<Client, BLL.Client>();
                cfg.CreateMap<Product, BLL.Product>();

            });

            return new Mapper(config);
        }
    }
}
