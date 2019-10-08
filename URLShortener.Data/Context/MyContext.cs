using Microsoft.EntityFrameworkCore; 
using URLShortener.Domain.Roles;
using URLShortener.Domain.Users;
using URLShortener.Domain.WebUrls;

namespace URLShortener.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        /// <summary>
        /// جدول لینک ها
        /// </summary>
        public DbSet<WebUrl> WebUrls { get; set; }
        /// <summary>
        /// جدول کاربران
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// جدول نقش ها
        /// </summary>
        public DbSet<Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }

}
