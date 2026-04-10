using MiniPokedex.Domain.Entities;

namespace MiniPokedex.Domain.Repositories;

public sealed record PokemonPageResult(int TotalCount, IReadOnlyCollection<Pokemon> Pokemon);

public interface IPokemonRepository
{
    Task<PokemonPageResult> GetPokemonPageAsync(int limit, int offset, CancellationToken cancellationToken = default);
    Task<PokemonPageResult> SearchByNameContainsAsync(string name, int limit, int offset, CancellationToken cancellationToken = default);
    Task<Pokemon?> GetByNameOrIdAsync(string nameOrId, CancellationToken cancellationToken = default);
}
