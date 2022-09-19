using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Logistica.Api.Models;

namespace Logistica.Api.Data
{
    public class LogisticaApiContext : DbContext
    {
        public LogisticaApiContext (DbContextOptions<LogisticaApiContext> options)
            : base(options)
        {
        }

        public DbSet<Logistica.Api.Models.Pedido> Pedido { get; set; }
    }
}
