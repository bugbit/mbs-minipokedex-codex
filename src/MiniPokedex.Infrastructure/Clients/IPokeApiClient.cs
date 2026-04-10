using MiniPokedex.Infrastructure.Dtos;

namespace MiniPokedex.Infrastructure.Clients;

public interface IPokeApiClient
{
    Task<PokeApiPokemonListResponse?> GetPokemonListAsync(int limit, int offset, CancellationToken cancellationToken = default);
    Task<PokeApiPokemonDetailResponse?> GetPokemonByNameOrIdAsync(string nameOrId, CancellationToken cancellationToken = default);
}
