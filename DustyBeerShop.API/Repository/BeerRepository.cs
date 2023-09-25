using DustyBeerShop.Domain;
using DustyBeerShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DustyBeerShop.API.Repository
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DataContext _dbContext;

        public BeerRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Beer>> GetBeers()
        {
            return await _dbContext.Beers.ToListAsync();
        }

        public async Task<Beer> GetBeer(Guid id)
        {
            return await _dbContext.Beers.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Beer> AddBeer(Beer beer)
        {
            var result = await _dbContext.Beers.AddAsync(beer);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Beer> UpdateBeer(Beer beer)
        {
            var result = await _dbContext.Beers.FirstOrDefaultAsync(e => e.Id == beer.Id);

            if (result != null)
            {
                result.Name = beer.Name;
                result.Description = beer.Description;
                result.Price = beer.Price;
                result.PictureUri = beer.PictureUri;
                result.BeerType = beer.BeerType;
                result.BeerBrand = beer.BeerBrand;

                await _dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task DeleteBeer(Guid id)
        {
            var result = await _dbContext.Beers.FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _dbContext.Beers.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}