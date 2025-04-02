using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plc.Models;

namespace PLC.Data
{
    public class PLCContext : DbContext
    {
        public PLCContext (DbContextOptions<PLCContext> options)
            : base(options)
        {
        }

        public DbSet<plc.Models.plCa> plCa { get; set; } = default!;
    }
}
