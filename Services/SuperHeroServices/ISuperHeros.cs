using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroServices
{
    public interface ISuperHeros
    {
        Task<List<SuperHero>> GetAllHeroes();

        Task<SuperHero?> GetSingleHero(int id);

        Task<List<SuperHero>> CreateHero(SuperHero newHero);

        Task<SuperHero?> UpdateSuperHero(int id, SuperHero request);


        Task<List<SuperHero>?> DeleteSuperHero(int id);

    }
}
