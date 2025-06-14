using BoutiqueFleurs.Models;
using Microsoft.EntityFrameworkCore;

namespace BoutiqueFleurs.Data
{
    public class BoutiqueFleursContext : DbContext
    {
        public BoutiqueFleursContext(DbContextOptions<BoutiqueFleursContext> options) : base(options)
        {
        }
        public DbSet<Fleur> Fleurs { get; set; }
    }
}