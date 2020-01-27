
using AutoMapper;

namespace BLL.Mapper
{
    public class SetupMapping
    {
        public static IMapper SetupMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Mapping.StartMapping(cfg);
            });

            return config.CreateMapper();
        }
    }
}
