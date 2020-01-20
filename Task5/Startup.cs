using Microsoft.Owin;
using Owin;
using Unity;
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

            BLL.Facade.SetupDependencies(container);
        }

        private IMapper SetupMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                BLL.Facade.SetupMapping(cfg);
            });

            return new Mapper(config);
        }
    }
}
