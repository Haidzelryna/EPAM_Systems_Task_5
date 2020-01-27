
using AutoMapper;

namespace BLL.Mapper
{
    public static class Mapping
    {
        public static void StartMapping(IMapperConfigurationExpression mapperCfg)
        {
            mapperCfg.CreateMap<DAL.Sale, BLL.Sale>();
            mapperCfg.CreateMap<DAL.Contact, BLL.Contact>();
            mapperCfg.CreateMap<DAL.Manager, BLL.Manager>();
            mapperCfg.CreateMap<DAL.Client, BLL.Client>();
            mapperCfg.CreateMap<DAL.Product, BLL.Product>();

            mapperCfg.CreateMap<BLL.Sale, DAL.Sale>();
            mapperCfg.CreateMap<BLL.Contact, DAL.Contact>();
            mapperCfg.CreateMap<BLL.Manager, DAL.Manager>();
            mapperCfg.CreateMap<BLL.Client, DAL.Client>();
            mapperCfg.CreateMap<BLL.Product, DAL.Product>();
        }
    }
}
