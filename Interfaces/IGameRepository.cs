using GameStoreMVC.Models;

namespace GameStoreMVC.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game?> GetByIdAsync(int id);
        Task AddAsync(Game game);
        Task UpdateAsync(Game game);
        Task DeleteAsync(int id);
        Task<IEnumerable<Game>> GetByCategoriaAsync(string categoria);
    }
}
