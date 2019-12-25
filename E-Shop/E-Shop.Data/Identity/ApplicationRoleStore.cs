namespace E_Shop.Data.Identity
{
    using ApplicationContext;

    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    ///     Just a wrapper for RoleStore<IdentityRole>
    /// </summary>
    public class ApplicationRoleStore : RoleStore<IdentityRole>
    {
        public ApplicationRoleStore(ApplicationContext context)
            : base(context)
        {
        }
    }
}