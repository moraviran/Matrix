using MatrixUsersManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MatrixUsersManagement.Data
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        
    }
}