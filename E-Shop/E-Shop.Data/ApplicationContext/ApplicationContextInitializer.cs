﻿namespace E_Shop.Data.ApplicationContext
{
    using System.Collections.Generic;
    using System.Data.Entity;

    using Model;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    ///     An implementation of CreateDatabaseIfNotExists
    /// </summary>
    public class ApplicationContextInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var orderStatuses = new List<OrderStatus>
                                    {
                                        new OrderStatus { Name = "Зарегистрирован" },
                                        new OrderStatus { Name = "Оплата разрешена" },
                                        new OrderStatus { Name = "Оплачен" },
                                        new OrderStatus { Name = "Выполнен" },
                                        new OrderStatus { Name = "Отменен" },
                                    };
            orderStatuses.ForEach(status => context.OrderStatuses.Add(status));

            var roles = new List<IdentityRole>
                            {
                                new IdentityRole("User"),
                                new IdentityRole("Manager"),
                                new IdentityRole("Admin")
                            };
            roles.ForEach(role => context.Roles.Add(role));

            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var user = new User { UserName = "Admin", Email = "Admin@nixelt.store" };
            manager.Create(user, "Admin");
        }
    }
}