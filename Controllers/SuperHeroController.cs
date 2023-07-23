using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroServices;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        // differentiate between the IActionResult and ActionResult<>
        private readonly ISuperHeros _superHeroService;

        public SuperHeroController(ISuperHeros superHeroService)
        {
            _superHeroService = superHeroService;
        }




        // create
        [HttpPost]
        public async Task<IActionResult> CreateHero(SuperHero newHero)
        {

            return Ok(await _superHeroService.CreateHero(newHero));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            return Ok(await _superHeroService.GetAllHeroes());
            
        }

        [HttpGet("{id}")] // the name should be similar to the following parameter
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _superHeroService.GetSingleHero(id);
            if (hero == null)
                return NotFound("Sorry, the hero doesn't exist");
            return Ok(hero);

        }

        // update
        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(int id, SuperHero request)
        {
            var hero = await _superHeroService.UpdateSuperHero(id, request);

            if (hero == null)
                return NotFound("hero not found, to update");
            return Ok(hero);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHero(int id)
        {
            var heros = await _superHeroService.DeleteSuperHero(id);
            if (heros == null)
                return NotFound("hero not found to delete");
            return Ok(heros);
        }


    }
}
