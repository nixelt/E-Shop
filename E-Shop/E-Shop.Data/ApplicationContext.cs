namespace E_Shop.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using E_Shop.Model.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Attribute> Attributes { get; set; }

        public IDbSet<AttributeValue> AttributeValues { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<OrderDetails> OrderDetails { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductImage> ProductImages { get; set; }

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
