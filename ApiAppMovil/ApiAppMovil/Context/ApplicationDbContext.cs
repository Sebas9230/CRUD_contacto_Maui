using Microsoft.EntityFrameworkCore;
using ApiAppMovil.Models;

namespace ApiAppMovil.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contacto> contactos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
