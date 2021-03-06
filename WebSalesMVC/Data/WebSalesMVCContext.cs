using Microsoft.EntityFrameworkCore;
using WebSalesMVC.Models;

namespace WebSalesMVC.Data
{
    public class WebSalesMVCContext : DbContext
    {
        public WebSalesMVCContext (DbContextOptions<WebSalesMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SaleRecord> SaleRecord { get; set; }
    }
}
