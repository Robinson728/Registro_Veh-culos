using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registro_Vehículos.Models;

namespace Registro_Vehículos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Vehiculos> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Vehiculos.db");
        }
    }
}
