using Microsoft.EntityFrameworkCore;
using peopleDB.Server.Models.Entities;

namespace peopleDB.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
    }
}
