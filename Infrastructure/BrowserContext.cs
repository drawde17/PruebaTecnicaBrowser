using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public partial class BrowserContext : DbContext
    {
        public BrowserContext() {}
        public BrowserContext(DbContextOptions<BrowserContext> options): base(options) { }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Localidad> Localidads { get; set; }
        public virtual DbSet<CarService> CarServices { get; set; }
        public virtual DbSet<CarStatus> CarStatus { get; set; }
    }
}
