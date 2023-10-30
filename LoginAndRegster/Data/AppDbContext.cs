    using LoginAndRegster.Models;
using System.Security.Policy;

namespace LoginAndRegster.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role[]
                {
                    new Role{ Id = 1 , RoleNem = "User"},
                    new Role{Id = 2 , RoleNem = "Admin"},
                    new Role{ Id = 3 , RoleNem ="SuperAdmin"},
                });
            modelBuilder.Entity<Employee>(entity => { entity.ToTable("Employees"); });
            modelBuilder.Entity<Customr>(entity =>
            {
                entity.ToTable("Customers");
            });

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customr> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
