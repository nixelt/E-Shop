namespace E_Shop.Mappings
{
    using AutoMapper;
    using AutoMapper.Configuration;

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {

            var config = new MapperConfigurationExpression();
            config.AddProfile<AdminToViewModel>();
            config.AddProfile<AdminFromViewModel>();
            config.AddProfile<ToViewModel>();
            config.AddProfile<FromViewModel>();
            Mapper.Initialize(config);
        }
    }
}