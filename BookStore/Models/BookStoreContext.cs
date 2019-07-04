using BookStore.config.EntityFramework;
using Microsoft.EntityFrameworkCore;
using entity = System.Data.Entity;

namespace BookStore.Models
{
    [entity.DbConfigurationType(typeof(CodeConfig))] // point to the class that inherit from DbConfiguration
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() { }
        public BookStoreContext(string connectionString): base(connectionString){}
        public DbSet<Book> Book { get; set; }
        public DbSet<Press> Press { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Address { get; set; }
        public class CodeConfig : entity.DbConfiguration
        {
            public CodeConfig()
            {
                SetProviderServices("System.Data.SqlClient",
                    System.Data.Entity.SqlServer.SqlProviderServices.Instance);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().OwnsOne(c => c.Address);
            new BookConfiguration(modelBuilder.Entity<Book>());
            new CategoryConfiguration(modelBuilder.Entity<Category>());
            new PressConfiguration(modelBuilder.Entity<Press>());
            new AddressConfiguration(modelBuilder.Entity<Address>());
        }
    }
}
