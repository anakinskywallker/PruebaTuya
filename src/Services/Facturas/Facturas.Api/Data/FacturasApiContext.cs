using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Facturas.Api.Models;

namespace Facturas.Api.Data
{
    public class FacturasApiContext : DbContext
    {
        public FacturasApiContext (DbContextOptions<FacturasApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Facturas> Facturas { get; set; }
    }
}
