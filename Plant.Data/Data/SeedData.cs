using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Data.Data
{
    internal class SeedData
    {
        private static Faker faker = null!;

        public static async Task InitAsync(PlantAPIContext db)
        {
            //if (await db.Event.AnyAsync()) return;

            faker = new Faker("sv");

            
        }
    }
}
