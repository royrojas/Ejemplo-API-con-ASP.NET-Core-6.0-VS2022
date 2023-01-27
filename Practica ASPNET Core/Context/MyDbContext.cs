using Microsoft.EntityFrameworkCore;
using Practica_ASPNET_Core.Models;

namespace Practica_ASPNET_Core.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
    }
}
