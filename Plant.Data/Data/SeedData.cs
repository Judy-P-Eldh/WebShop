using Bogus;
using Microsoft.EntityFrameworkCore;
using Plant.Core.Enteties;

namespace Plant.Data.Data;

public class SeedData
{
    private static Faker faker = null!;

    public static async Task InitAsync(PlantAPIContext db)
    {
        if (await db.Event.AnyAsync()) return;

        faker = new Faker("sv");

        //var offers = GetOffer(5);
        //await db.AddRangeAsync(offers);

        var events = GetEvent();
        await db.AddRangeAsync(events);

        await db.SaveChangesAsync();
    }

    private static IEnumerable<Event> GetEvent()
    {
        var events = new List<Event>();

        for (int i = 0; i < 5; i++)
        {
            var oneEvent = new Event()
            {
                Title = faker.Commerce.ProductName(),
                Date = faker.Date.Soon(),
                Description = faker.Company.CatchPhrase(),
                Address = new Address()
                {
                    Street = faker.Address.StreetName(),
                    StreetNr = faker.Random.Number(200),
                    City = faker.Address.City(),
                    PostalCode = faker.Address.ZipCode(),
                },

                Offers = GetOffer(faker.Random.Int(0, 5))
            };

            events.Add(oneEvent);
        }

        return events;
    }

    private static List<Offer> GetOffer(int n)
    {
        var rnd = new Random();
        var offers = new List<Offer>();
        for (int i = 0; i < n; i++)
        {
            var offer = new Offer()
            {
                Title = faker.Commerce.Department(),
                Description = faker.Commerce.ProductDescription(),
                StartDate = faker.Date.Soon(),
                Discount = rnd.Next(0, 76)
            };
            offers.Add(offer);
        }
        return offers;
    }

}









