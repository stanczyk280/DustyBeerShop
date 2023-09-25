using DustyBeerShop.Domain;

namespace DustyBeerShop.Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Beers.Any())
                return;

            var beers = new List<Beer>
            {
                new Beer
                {
                    Name = "Test",
                    Description = "Test",
                    Price = 1.5,
                    PictureUri = "test",
                    BeerType = "Test",
                    BeerBrand = "Test"
                },
                new Beer
                {
                    Name = "Test2",
                    Description = "Tes2",
                    Price = 2.5,
                    PictureUri = "test2",
                    BeerType = "Test2",
                    BeerBrand = "Test2"
                },
                new Beer
                {
                    Name = "Test3",
                    Description = "Test3",
                    Price = 3.5,
                    PictureUri = "test3",
                    BeerType = "Test3",
                    BeerBrand = "Test3"
                },
            };

            await context.Beers.AddRangeAsync(beers);
            await context.SaveChangesAsync();
        }
    }
}