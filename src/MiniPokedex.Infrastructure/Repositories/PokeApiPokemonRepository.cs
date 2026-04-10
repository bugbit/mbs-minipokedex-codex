using MiniPokedex.Domain.Entities;
using MiniPokedex.Domain.Repositories;
using MiniPokedex.Domain.ValueObjects;
using MiniPokedex.Infrastructure.Clients;

namespace MiniPokedex.Infrastructure.Repositories;

public sealed class PokeApiPokemonRepository(IPokeApiClient client) : IPokemonRepository
{
    private const int MaxPokemonListLimit = 2000;
    private readonly IPokeApiClient _client = client;

    public async Task<PokemonPageResult> GetPokemonPageAsync(int limit, int offset, CancellationToken cancellationToken = default)
    {
        var listResponse = await _client.GetPokemonListAsync(limit, offset, cancellationToken);
        if (listResponse?.Results.Count is not > 0)
        {
            return new PokemonPageResult(listResponse?.Count ?? 0, []);
        }

        var tasks = listResponse.Results
            .Where(item => !string.IsNullOrWhiteSpace(item.Name))
            .Select(item => _client.GetPokemonByNameOrIdAsync(item.Name, cancellationToken));

        var details = await Task.WhenAll(tasks);

        var pokemon = details
            .Where(detail => detail is not null)
            .Select(detail => ToDomain(detail!))
            .ToArray();

        return new PokemonPageResult(listResponse.Count, pokemon);
    }

    public async Task<PokemonPageResult> SearchByNameContainsAsync(string name, int limit, int offset, CancellationToken cancellationToken = default)
    {
        var normalizedName = name.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
        {
            return new PokemonPageResult(0, []);
        }

        var listResponse = await _client.GetPokemonListAsync(MaxPokemonListLimit, 0, cancellationToken);
        if (listResponse?.Results.Count is not > 0)
        {
            return new PokemonPageResult(0, []);
        }

        var matchedNames = listResponse.Results
            .Where(item => !string.IsNullOrWhiteSpace(item.Name))
            .Select(item => item.Name)
            .Where(itemName => itemName.Contains(normalizedName, StringComparison.OrdinalIgnoreCase))
            .ToArray();

        var totalCount = matchedNames.Length;
        if (totalCount == 0)
        {
            return new PokemonPageResult(0, []);
        }

        var pageNames = matchedNames
            .Skip(offset)
            .Take(limit)
            .ToArray();

        var details = await Task.WhenAll(pageNames.Select(pageName => _client.GetPokemonByNameOrIdAsync(pageName, cancellationToken)));

        var pokemon = details
            .Where(detail => detail is not null)
            .Select(detail => ToDomain(detail!))
            .ToArray();

        return new PokemonPageResult(totalCount, pokemon);
    }

    public async Task<Pokemon?> GetByNameOrIdAsync(string nameOrId, CancellationToken cancellationToken = default)
    {
        var detail = await _client.GetPokemonByNameOrIdAsync(nameOrId, cancellationToken);
        return detail is null ? null : ToDomain(detail);
    }

    private static Pokemon ToDomain(Dtos.PokeApiPokemonDetailResponse dto) =>
        new(
            new PokemonId(dto.Id),
            dto.Name,
            dto.Height,
            dto.Weight,
            dto.BaseExperience,
            dto.Sprites.Other?.OfficialArtwork?.FrontDefault
                ?? dto.Sprites.FrontDefault
                ?? string.Empty,
            dto.Sprites.Other?.OfficialArtwork?.FrontShiny
                ?? dto.Sprites.FrontShiny,
            dto.Types.Select(t => new PokemonType(t.Type.Name)).ToArray(),
            dto.Abilities
                .Where(a => !string.IsNullOrWhiteSpace(a.Ability.Name))
                .Select(a => new PokemonAbility(a.Ability.Name, a.IsHidden))
                .ToArray(),
            dto.Stats
                .Where(s => !string.IsNullOrWhiteSpace(s.Stat.Name))
                .Select(s => new PokemonBaseStat(s.Stat.Name, s.BaseStat))
                .ToArray());
}
