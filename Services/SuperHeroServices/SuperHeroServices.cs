using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroServices
{
    public class SuperHeroServices : ISuperHeros
    {

        // access the database
        private readonly DataContext _context;

        public SuperHeroServices(DataContext context)
        {
            _context = context;
        }


        public async Task<List<SuperHero>> CreateHero(SuperHero newHero)
        {
            _context.SuperHeroes.Add(newHero);
            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }

       

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var superHeroes = await _context.SuperHeroes.ToListAsync();
            return superHeroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            return hero;
        }

        public async Task<SuperHero?> UpdateSuperHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return null;

            

            if (request.Name != null){ hero.Name = request.Name; }
            
            if (request.FirstName != null){ hero.FirstName = request.FirstName;}
            
            if (request.LastName != null) { hero.LastName = request.LastName; }
            
            if (request.Place  != null) { hero.Place = request.Place; }

            await _context.SaveChangesAsync();
            return hero;

        }


        public async Task<List<SuperHero>?> DeleteSuperHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();


            return await GetAllHeroes();
        }

    }
}
