using MiniPokedex.Application.Abstractions;
using MiniPokedex.Application.DTOs;
using MiniPokedex.Domain.Repositories;

namespace MiniPokedex.Application.Services;

public sealed class PokemonQueryService(IPokemonRepository repository) : IPokemonQueryService
{
    public async Task<PokemonPageDto> GetPokemonPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var normalizedPage = Math.Max(page, 1);
        var normalizedPageSize = Math.Clamp(pageSize, 1, 50);
        var offset = (normalizedPage - 1) * normalizedPageSize;

        var pokemonPage = await repository.GetPokemonPageAsync(normalizedPageSize, offset, cancellationToken);
        var pokemon = pokemonPage.Pokemon
            .Select(p => new PokemonSummaryDto(p.Id.Value, p.Name, p.SpriteUrl))
            .ToArray();

        return new PokemonPageDto(
            normalizedPage,
            normalizedPageSize,
            pokemonPage.TotalCount,
            pokemon);
    }

    public async Task<PokemonDetailDto?> GetPokemonAsync(string nameOrId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(nameOrId))
        {
            return null;
        }

        var pokemon = await repository.GetByNameOrIdAsync(nameOrId.Trim(), cancellationToken);
        if (pokemon is null)
        {
            return null;
        }

        return new PokemonDetailDto(
            pokemon.Id.Value,
            pokemon.Name,
            pokemon.Height,
            pokemon.Weight,
            pokemon.SpriteUrl,
            pokemon.Types.Select(t => t.Name).ToArray());
    }
}
