namespace E_Shop.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using Data.Identity;

    using ViewModels.AccountViewModels;
    using ViewModels.SettingsViewModels;

    using Filters;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    using Model;

    using Web.Core.Extensions;

    public class AccountController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        // GET: /Account/Login
        [OnlyAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [OnlyAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, shouldLockout: false).ConfigureAwait(false);

            switch (result)
            {
                case SignInStatus.Success:
                    Logger.Log.Info($"{model.Email} вошел в аккаунт");
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = true });
                default:
                    ModelState.AddModelError(string.Empty, @"Неверные данные.");
                    return View(model);
            }
        }

        // GET: /Account/Register
        [OnlyAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register  
        [HttpPost]
        [OnlyAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, MiddleName = model.MiddleName, LastName = model.LastName, PhoneNumber = model.Phone };
                var errors = _userManager.CanAddUser(user);
                ModelState.AddModelErrors(errors);
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    Logger.Log.Info($"На сайте появился новый пользователь {model.Email}");
                    var currentUser = await _userManager.FindByEmailAsync(user.Email).ConfigureAwait(false);
                    await _userManager.AddToRoleAsync(currentUser.Id, "User").ConfigureAwait(false);
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: true).ConfigureAwait(false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id).ConfigureAwait(false);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code }, protocol: Request.Url.Scheme);
                    await _userManager.SendEmailAsync(
                            user.Id,
                            "Подтвердите электронную почту",
                            "Чтобы подтвердить регистрацию <a href=\"" + callbackUrl + "\">кликните здесь</a>")
                        .ConfigureAwait(false);


                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelErrors(result.Errors.Select(x => new ValidationResult(x)));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(userId, code).ConfigureAwait(false);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email).ConfigureAwait(false);
                if (user == null)
                {
                    // Don't reveal that the user does not exist
                    return View("ForgotPasswordConfirmation");
                }

                // Send an email with this link
                var code = await _userManager.GeneratePasswordResetTokenAsync(user.Id).ConfigureAwait(false);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code }, protocol: Request.Url.Scheme);
                await _userManager.SendEmailAsync(user.Id, "Восстановаление пароля", "Сбросьте пароль нажав <a href=\"" + callbackUrl + "\">здесь</a>").ConfigureAwait(false);
                Logger.Log.Info($"Пользователю {user.UserName} было отправлено сообщение с ссылкой для восстановления пароля");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Email).ConfigureAwait(false);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.Password).ConfigureAwait(false);
            if (result.Succeeded)
            {
                Logger.Log.Info($"Пользоветль {user.UserName} сбросил пароль");
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            ModelState.AddModelErrors(result.Errors.Select(x => new ValidationResult(x)));
            return View();
        }

        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await _signInManager.HasBeenVerifiedAsync().ConfigureAwait(false))
            {
                return View("Error");
            }

            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await _signInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser).ConfigureAwait(false);
            switch (result)
            {
                case SignInStatus.Success:
                    Logger.Log.Info($"{User.Identity.GetUserName()}  вошел на сайт используя двухфакторную аутентификацию");
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                default:
                    ModelState.AddModelError(string.Empty, @"Неверный код.");
                    return View(model);
            }
        }

        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await _signInManager.GetVerifiedUserIdAsync().ConfigureAwait(false);
            if (userId == null)
            {
                return View("Error");
            }

            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(userId).ConfigureAwait(false);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await _signInManager.SendTwoFactorCodeAsync(model.SelectedProvider).ConfigureAwait(false))
            {
                return View("Error");
            }

            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, model.ReturnUrl, model.RememberMe });
        }

        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync().ConfigureAwait(false);
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await _signInManager.ExternalSignInAsync(loginInfo, isPersistent: false).ConfigureAwait(false);
            switch (result)
            {
                case SignInStatus.Success:
                    Logger.Log.Info($"{User.Identity.Name} вошел на сайт используя внешний ресурс");
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Settings");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync().ConfigureAwait(false);
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                var user = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, MiddleName = model.MiddleName, LastName = model.LastName, PhoneNumber = model.Phone };
                var result = await _userManager.CreateAsync(user).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user.Id, info.Login).ConfigureAwait(false);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user.Id, "User").ConfigureAwait(false);
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false).ConfigureAwait(false);
                        Logger.Log.Info($"{User.Identity.Name} зарегистрировался на сайте используя внешний сервис");
                        return RedirectToLocal(returnUrl);
                    }
                }

                ModelState.AddModelErrors(result.Errors.Select(x => new ValidationResult(x)));
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [System.Web.Mvc.Authorize]
        public ActionResult LogOff()
        {
            Logger.Log.Info($"{User.Identity.Name} вышел из аккаунта");
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            // Used for XSRF protection when adding external logins
            private const string XsrfKey = "XsrfId";

            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }

            public string RedirectUri { get; set; }

            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }

                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
    }
}