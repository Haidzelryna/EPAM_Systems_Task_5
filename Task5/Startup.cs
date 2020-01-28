using Microsoft.Owin;
using Owin;
using Unity;
using AutoMapper;
using BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Unity;


[assembly: OwinStartupAttribute(typeof(Task5.Startup))]
namespace Task5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


        private IMapper SetupMapper()
        {
            var config = new MapperConfiguration(mapperCfg =>
            {
                Facade.SetupMapping(mapperCfg);

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

            return new Mapper(config);
        }

    }
}
