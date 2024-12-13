
using HakatonG.Models;
using Microsoft.EntityFrameworkCore;

namespace HakatonG.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }


    }   
}
