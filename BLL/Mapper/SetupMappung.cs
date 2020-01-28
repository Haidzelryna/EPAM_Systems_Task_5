﻿
using AutoMapper;

namespace BLL.Mapper
{
    public class SetupMapping
    {
        public static IMapper SetupMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Facade.SetupMapping(cfg);
            });

            return config.CreateMapper();
        }
    }
}
