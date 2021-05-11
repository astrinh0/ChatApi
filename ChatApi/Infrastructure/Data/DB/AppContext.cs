using ChatApi.Infrastructure.Mappers;
using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Infrastructure.DB
{
    public class AppContext : DbContext
    
    {
        public AppContext(DbContextOptions<AppContext> options) : base (options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupMessage> GroupMessages { get; set; }


     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("ChatApi");
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new MessageMap());
            builder.ApplyConfiguration(new GroupMap());
            builder.ApplyConfiguration(new GroupMessageMap());
            builder.ApplyConfiguration(new UserMessageMap());
        }
        
        
    }
}