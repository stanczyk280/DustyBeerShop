using DustyBeerShop.API.Repository;
using DustyBeerShop.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace DustyBeerShop.API.Controllers
{
    public class BeerController : BaseApiController
    {
        private readonly IBeerRepository _beerRepository;

        public BeerController(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        // GET: api/beers
        [HttpGet]
        public async Task<ActionResult<List<Beer>>> GetBeers()
        {
            try
            {
                return Ok(await _beerRepository.GetBeers());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error occured when retriving data from the database");
            }
        }

        // GET api/beers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Beer>> GetBeer(Guid id)
        {
            try
            {
                var beer = await _beerRepository.GetBeer(id);
                if (beer == null)
                {
                    return NotFound();
                }

                return beer;
            }
            catch (Exception)
            {
                return StatusCode(500, "Error occured when retriving data from the database");
            }
        }

        // POST api/beers
        [HttpPost]
        public async Task<ActionResult<Beer>> PostBeer(Beer beer)
        {
            try
            {
                if (beer == null)
                {
                    return BadRequest();
                }

                var postedBeer = await _beerRepository.AddBeer(beer);

                return CreatedAtAction(nameof(GetBeer), new { id = postedBeer.Id }, postedBeer);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error occured when retriving data from the database");
            }
        }

        // PUT api/beers/5
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Beer>> PutBeer(Guid id, Beer beer)
        {
            try
            {
                if (id != beer.Id)
                {
                    return BadRequest($"Id missmatch Given id: {id}, Checked id: {beer.Id}");
                }
                var beerToUpdate = await _beerRepository.GetBeer(id);

                if (beerToUpdate == null)
                {
                    return NotFound($"Given beer of \"{id}\" not found");
                }

                return await _beerRepository.UpdateBeer(beer);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error occured when trying to update data");
            }
        }

        // DELETE api/beers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Beer>> DeleteBeer(Guid id)
        {
            try
            {
                var beerToDelete = await _beerRepository.GetBeer(id);

                if (beerToDelete == null)
                {
                    return NotFound($"Given beer of \"{id}\" not found");
                }

                await _beerRepository.DeleteBeer(id);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Error occured when trying to delete data");
            }
        }
    }
}