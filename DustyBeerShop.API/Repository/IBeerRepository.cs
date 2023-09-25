using DustyBeerShop.Domain;

namespace DustyBeerShop.API.Repository
{
    public interface IBeerRepository
    {
        Task<IEnumerable<Beer>> GetBeers();

        Task<Beer> GetBeer(Guid id);

        Task<Beer> AddBeer(Beer beer);

        Task<Beer> UpdateBeer(Beer beer);

        Task DeleteBeer(Guid id);
    }
}