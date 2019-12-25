using System.Web;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(E_Shop.Startup))]

namespace E_Shop
{
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using Data.Identity;
    using Data.Infrastructure;
    using Data.Repositories;

    using Data.ApplicationContext;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security.DataProtection;

    using Model;

    using Owin;

    using Service;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);
            ConfigureAuth(app);
        }

        private static void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();
            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationRoleStore>().As<IRoleStore<IdentityRole, string>>();

            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerRequest();
            builder.RegisterType<SmscSender>().As<ISmsSender>().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly).Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly).Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}