using Microsoft.EntityFrameworkCore;
using QuadraManagementService.Entities;

namespace QuadraManagementService.Infrastructure.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Quadras> Quadras { get; set; }

        //public DbSet<Agendamentos> Agendamentos { get; set; }
    }
}
