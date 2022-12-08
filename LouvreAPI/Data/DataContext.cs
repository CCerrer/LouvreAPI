using LouvreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LouvreAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Pintura> Pinturas { get; set; }
    }
}
