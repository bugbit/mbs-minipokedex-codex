using MiniPokedex.Domain.Entities;
using MiniPokedex.Domain.Repositories;
using MiniPokedex.Domain.ValueObjects;
using MiniPokedex.Infrastructure.Clients;

namespace MiniPokedex.Infrastructure.Repositories;

public sealed class PokeApiPokemonRepository(IPokeApiClient client) : IPokemonRepository
{
    public async Task<PokemonPageResult> GetPokemonPageAsync(int limit, int offset, CancellationToken cancellationToken = default)
    {
        var listResponse = await client.GetPokemonListAsync(limit, offset, cancellationToken);
        if (listResponse?.Results.Count is not > 0)
        {
            return new PokemonPageResult(listResponse?.Count ?? 0, []);
        }

        var tasks = listResponse.Results
            .Where(item => !string.IsNullOrWhiteSpace(item.Name))
            .Select(item => client.GetPokemonByNameOrIdAsync(item.Name, cancellationToken));

        var details = await Task.WhenAll(tasks);

        var pokemon = details
            .Where(detail => detail is not null)
            .Select(detail => ToDomain(detail!))
            .ToArray();

        return new PokemonPageResult(listResponse.Count, pokemon);
    }

    public async Task<Pokemon?> GetByNameOrIdAsync(string nameOrId, CancellationToken cancellationToken = default)
    {
        var detail = await client.GetPokemonByNameOrIdAsync(nameOrId, cancellationToken);
        return detail is null ? null : ToDomain(detail);
    }

    private static Pokemon ToDomain(Dtos.PokeApiPokemonDetailResponse dto) =>
        new(
            new PokemonId(dto.Id),
            dto.Name,
            dto.Height,
            dto.Weight,
            dto.Sprites.FrontDefault ?? string.Empty,
            dto.Types.Select(t => new PokemonType(t.Type.Name)).ToArray());
}
