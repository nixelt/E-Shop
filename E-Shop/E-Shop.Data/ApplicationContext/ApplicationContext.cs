namespace E_Shop.Data.ApplicationContext
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Model;

    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    ///     It is a bridge between entity classes and the database of this application
    /// </summary>
    public sealed class ApplicationContext : IdentityDbContext<User>
    {
        static ApplicationContext()
        {
            Database.SetInitializer(new ApplicationContextInitializer());
        }

        public ApplicationContext()
            : base("nixelts1_store")
        {
        }

        public IDbSet<Attribute> Attributes { get; set; }

        public IDbSet<AttributeValue> AttributeValues { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Log> Logs { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<OrderDetails> OrderDetails { get; set; }

        public IDbSet<OrderStatus> OrderStatuses { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductImage> ProductImages { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Supplier> Suppliers { get; set; }

        public IDbSet<Supply> Supplies { get; set; }

        public IDbSet<SupplyProduct> SupplyProducts { get; set; }

        public override IDbSet<User> Users { get; set; }

        public void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}
