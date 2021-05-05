using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
namespace ChatApi.Infrastructure.DB
{
    public class DataContext : DbContext
    
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
                

        }
        
        
    }
}