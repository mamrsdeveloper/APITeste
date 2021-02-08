using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Context : DbContext
    {


        public Context(DbContextOptions<Context> options)
         : base(options)
        { }

        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
    }
}
