namespace E_Shop
{
    using System;

    using Data.Identity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.Google;

    using Model;

    using Owin;

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                  new CookieAuthenticationOptions
                  {
                      AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                      LoginPath = new PathString("/Account/Login"),
                      Provider = new CookieAuthenticationProvider
                      {
                          OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                          validateInterval: TimeSpan.FromMinutes(30),
                          regenerateIdentity: (manager, user) => manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie))
                      }
                  });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "934875750933-hdld5cod68mtv74g5jlnf5ltn8avq491.apps.googleusercontent.com",
                ClientSecret = "TINF0vjM8DjfI4Nh2_5CyowR"
            });
        }
    }
}