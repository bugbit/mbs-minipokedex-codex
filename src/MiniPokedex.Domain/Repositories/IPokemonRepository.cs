using MiniPokedex.Domain.Entities;

namespace MiniPokedex.Domain.Repositories;

public interface IPokemonRepository
{
    Task<IReadOnlyCollection<Pokemon>> GetPokemonPageAsync(int limit, int offset, CancellationToken cancellationToken = default);
    Task<Pokemon?> GetByNameOrIdAsync(string nameOrId, CancellationToken cancellationToken = default);
}
