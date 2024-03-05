using Microsoft.EntityFrameworkCore;
using eCommerce.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace eCommerce.Dal
{
    public class ECommerceDbContext : DbContext 
    {
        protected readonly IConfiguration Configuration;
        public ECommerceDbContext()
        {
            
        }
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options, IConfiguration configuration) : base(options)
        {

            Configuration = configuration;

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ByteJanECommerceDb24;Trusted_Connection=True;TrustServerCertificate=True;");
                optionsBuilder.UseNpgsql("Host=localhost; Database=ByteJanECommerceDb24; Username=postgres; Password=12345678");
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("eCommerceConStr"));
                //optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));

            }
        }
    }
}
