using ChatApi.Infrastructure.Data.Mappers;
using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.Mappers;
using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Infrastructure.DB
{
    public class DataContext : DbContext
    
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupMessage> GroupMessages { get; set; }

        public DbSet<UserMessage> UserMessages { get; set; }

        public DbSet<GroupUser> GroupUsers { get; set; }

        public DbSet<File> Files { get; set; }




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
            builder.ApplyConfiguration(new GroupUserMap());
            builder.ApplyConfiguration(new FileMap());
        }
        
        
    }
}