using Microsoft.Owin;
using Owin;
using Unity;
using DAL;
using AutoMapper;

[assembly: OwinStartupAttribute(typeof(Task5.Startup))]
namespace Task5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            ConfigureContainer(container);
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterInstance(SetupMapper());

            Facade.SetupDependencies(container);
        }

        private IMapper SetupMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Facade.SetupMapping(cfg);

                cfg.CreateMap<BLL.Sale, DALSale>();
                cfg.CreateMap<BLL.Contact, DContact>();
                cfg.CreateMap<BLL.Manager, DAL.Manager>();
                cfg.CreateMap<BLL.Client, DAL.Client>();
                cfg.CreateMap<BLL.Product, DAL.Product>();

                cfg.CreateMap<DAL.Sale, BLL.Sale>();
                cfg.CreateMap<DAL.Contact, BLL.Contact>();
                cfg.CreateMap<DAL.Manager, BLL.Manager>();
                cfg.CreateMap<DAL.Client, BLL.Client>();
                cfg.CreateMap<DAL.Product, BLL.Product>();

            });

            return new Mapper(config);
        }
    }
}
