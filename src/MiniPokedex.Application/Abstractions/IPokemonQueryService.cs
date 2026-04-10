using MiniPokedex.Application.DTOs;

namespace MiniPokedex.Application.Abstractions;

public interface IPokemonQueryService
{
    Task<PokemonPageDto> GetPokemonPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<PokemonDetailDto?> GetPokemonAsync(string nameOrId, CancellationToken cancellationToken = default);
}
