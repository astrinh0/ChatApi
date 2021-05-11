using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Infrastructure.DB
{
    public class MessageContext : DbContext
    {
        public DbSet<Message> Users { get; set; }

        public MessageContext(DbContextOptions<UserContext> options) :
            base(options)
        {
        }
    }
}