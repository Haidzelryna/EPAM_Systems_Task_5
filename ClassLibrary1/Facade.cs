﻿using AutoMapper;
using Unity;
using BLL.Services;

namespace BLL
{
    public static class Facade
    {
        public static void SetupMapping(IMapperConfigurationExpression mapperCfg)
        {
            DAL.Facade.SetupMapping(mapperCfg);

            mapperCfg.CreateMap<BLL.Sale, DAL.Sale>();
            mapperCfg.CreateMap<BLL.Contact, DAL.Contact>();
            mapperCfg.CreateMap<BLL.Manager, DAL.Manager>();
            mapperCfg.CreateMap<BLL.Client, DAL.Client>();
            mapperCfg.CreateMap<BLL.Product, DAL.Product>();
        }

        public static void SetupDependencies(IUnityContainer unityContainer)
        {
            DAL.Facade.SetupDependencies(unityContainer);

            unityContainer.RegisterSingleton<IService, ContactService>();
            unityContainer.RegisterSingleton<IService, ClientService>();
            unityContainer.RegisterSingleton<IService, ManagerService>();
            unityContainer.RegisterSingleton<IService, ProductService>();
            unityContainer.RegisterSingleton<IService, SaleService>();
        }
    }
}
