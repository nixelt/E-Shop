namespace E_Shop
{
    using Mappings;

    public static class Bootstrapper
    {
        public static void Run()
        {
            AutoMapperConfiguration.Configure();
        }
    }
}