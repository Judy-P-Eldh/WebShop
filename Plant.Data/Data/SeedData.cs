﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using Plant.Core.Enteties;

namespace Plant.Data.Data;

public class SeedData
{
    private static Faker faker = null!;

    public static async Task InitAsync(PlantAPIContext db, IServiceProvider service)
    {
        if (await db.Event.AnyAsync()) return;

        faker = new Faker("sv");

        var offers = GetOffer();
        await db.AddRangeAsync(offers);

        var events = GetEvent();
        await db.AddRangeAsync(events);

        await db.SaveChangesAsync();


    }

  
    private static IEnumerable<Event> GetEvent()
    {
        var events = new List<Event>();

        for (int i = 0; i < 20; i++)
        {
            var oneEvent = new Event()
            {
                Title = faker.Company.CompanyName(),
                Date = faker.Date.Soon(),
                Description = faker.Company.CatchPhrase(),
                Address = new Address()
                {
                    Street = faker.Address.StreetName(),
                    StreetNr = faker.Random.Number(1 - 89),
                    City = faker.Address.City(),
                    PostalCode = faker.Address.ZipCode(),
                }
            };

            foreach (var e in events)
            {
                if (faker.Random.Int(0, 5) == 0)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        GetOffer();
                    }
                    
                }
            }
            
            events.Add(oneEvent);
        }
        
        return events;
    }

    private static List<Offer> GetOffer()
    {
        var offers = new List<Offer>();
        for (int i = 0; i < 20; i++)
        {
            var offer = new Offer()
            {
                Title = faker.Commerce.Department(),
                Description = faker.Commerce.ProductDescription(),
                StartDate = faker.Date.Soon(),
                Discount = faker.Random.Int(11 - 75)
            };
            offers.Add(offer);
        }
        return offers;
    }

}








