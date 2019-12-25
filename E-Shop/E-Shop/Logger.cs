namespace E_Shop
{
    using log4net;

    public static class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger("LOGGER");
    }
}