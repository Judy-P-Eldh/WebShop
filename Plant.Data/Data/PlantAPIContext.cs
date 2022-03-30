#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plant.Core.Enteties;

namespace Plant.Data.Data
{
    public class PlantAPIContext : DbContext
    {
        public PlantAPIContext (DbContextOptions<PlantAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }

        public DbSet<Offer> Offer { get; set; }
    }
}
