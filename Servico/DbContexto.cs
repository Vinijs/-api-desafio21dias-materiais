

using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Servicos
{
    public class DbContexto: DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options): base(options)  { }

        public DbSet<Material> Materiais { get; set; }
    }

}