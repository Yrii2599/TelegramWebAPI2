using DAL.Initialize;
using HelpersLayer;
using Microsoft.EntityFrameworkCore;
using ModelsLayer;


namespace DAL.Context
{
    public class TelegramContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageReceivers> MessageReceivers  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringInstaller.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public TelegramContext(DbContextOptions<TelegramContext> options) : base(options)
        {
            //Database.EnsureCreated();
           // Database.EnsureDeleted();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            TelegramContextInitializer.Initialize(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
