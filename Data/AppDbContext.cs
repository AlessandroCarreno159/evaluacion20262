using Microsoft.EntityFrameworkCore;
using tecnogas.Models;

namespace tecnogas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SolicitudServicio> Solicitudes { get; set; }
    }
}
