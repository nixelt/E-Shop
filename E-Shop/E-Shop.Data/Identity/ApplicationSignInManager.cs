namespace E_Shop.Data.Identity
{
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    using Model;

    /// <summary>
    ///     Just a wrapper for SignInManager<User, string>
    /// </summary>
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}
