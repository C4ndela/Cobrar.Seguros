using CobrarSeguros.BD.Data.entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobrarSeguros.BD.Data
{//representacion de base de datos
    public class BDcontext : DbContext
    {
        
        public DbSet <Clientes> Cliente { get; set; }
        public DbSet <Vehiculo> Vehiculos { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public BDcontext(DbContextOptions options) : base(options)
        {
           
        }

    }
}
