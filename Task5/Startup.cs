using Microsoft.Owin;
using Owin;
using Unity;
using AutoMapper;
using BLL;

[assembly: OwinStartupAttribute(typeof(Task5.Startup))]
namespace Task5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
