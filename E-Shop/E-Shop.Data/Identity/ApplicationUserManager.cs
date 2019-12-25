using System.ComponentModel.DataAnnotations;

namespace E_Shop.Data.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security.DataProtection;

    using Model;

    /// <summary>
    ///     ApplicationUserManager to work with entity User
    /// </summary>
    public class ApplicationUserManager : UserManager<User>
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public ApplicationUserManager(IUserStore<User> store, IDataProtectionProvider dataProtectionProvider, ISmsSender smsSender, IEmailSender emailSender)
            : base(store)
        {
            _dataProtectionProvider = dataProtectionProvider;
            SmsService = smsSender;
            EmailService = emailSender;
            CreateApplicationUserManager();
        }

        public List<User> GetUsers(bool onlyBlocked = false)
        {
            var users = onlyBlocked
                            ? Users.Where(user => user.LockoutEndDateUtc > DateTime.Now)
                            : Users;
            return users.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public IEnumerable<ValidationResult> CanAddUser(User newUser)
        {
            User user;
            if (newUser.Id == null)
            {
                user = Users.FirstOrDefault(x => x.PhoneNumber == newUser.PhoneNumber);
            }
            else
            {
                user = Users.FirstOrDefault(x => x.PhoneNumber == newUser.PhoneNumber && x.Id != newUser.Id);
            }

            if (user != null)
            {
                yield return new ValidationResult("Пользователь с данным телефоном уже существует!");
            }
        }

        private void CreateApplicationUserManager()
        {
            RegisterTwoFactorProvider(
                "Смс",
                new PhoneNumberTokenProvider<User, string>
                {
                    MessageFormat = "Ваш код -  {0}"
                });

            RegisterTwoFactorProvider(
                "Электронная почта",
                new EmailTokenProvider<User, string>
                {
                    Subject = "Ваш код",
                    BodyFormat = "Ваш код - {0}"
                });

            if (_dataProtectionProvider != null)
            {
                var dataProtector = _dataProtectionProvider.Create("ASP.NET Identity");
                UserTokenProvider = new DataProtectorTokenProvider<User, string>(dataProtector);
            }
        }
    }
}