using Microsoft.EntityFrameworkCore;
namespace Auth_Login.Models
{
    public class LoginDbcontext : DbContext
    {
        public LoginDbcontext(DbContextOptions<LoginDbcontext> options) : base(options) { }

        public DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(k => k.id);
            });

            builder.Entity<UserLogin>().HasData(
                new UserLogin { id = 101, UserName = "Gaurav", passcode = "pass@123", isActive = 1 },
                new UserLogin { id = 102, UserName = "Kundan", passcode = "pass@123", isActive = 1 }
            );
        }
    }
}
