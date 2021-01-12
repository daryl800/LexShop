using System.Data.Entity;
using LexShop.Core.Models;

namespace LexShop.DataAccess.SQL
{
    class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCatagories { get; set; }
    }
}