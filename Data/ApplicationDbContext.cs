using Microsoft.EntityFrameworkCore;
using shop_api.Models;

namespace shop_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       public DbSet<Shop> Shops { get; set; }
       public DbSet<Mall> Malls { get; set; }
        public DbSet<ShopTag> ShopTags { get; set; }
        public DbSet<Tag> Tags { get; set; }


    }

}
