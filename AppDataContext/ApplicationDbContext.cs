using Todo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Todo.AppDataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<ToDo>? Todos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDo>()
                .HasOne(u => u.User)
                .WithMany(t => t.ToDos)
                .HasForeignKey(f => f.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);
            
             List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name ="Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

        }
        
        

    }
}