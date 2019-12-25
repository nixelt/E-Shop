namespace E_Shop.Data.Identity
{
    using ApplicationContext;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Model;

    /// <summary>
    ///     Just a wrapper for UserStore<User>
    /// </summary>
    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(ApplicationContext context)
            : base(context)
        {
        }
    }
}
