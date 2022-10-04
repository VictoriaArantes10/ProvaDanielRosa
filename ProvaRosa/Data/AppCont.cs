using Microsoft.EntityFrameworkCore;
using Prova.Models;

namespace Prova.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
