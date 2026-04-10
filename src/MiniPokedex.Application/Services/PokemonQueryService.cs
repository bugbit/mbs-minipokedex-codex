using MiniPokedex.Application.Abstractions;
using MiniPokedex.Application.DTOs;
using MiniPokedex.Domain.Repositories;

namespace MiniPokedex.Application.Services;

public sealed class PokemonQueryService(IPokemonRepository repository) : IPokemonQueryService
{
    private readonly IPokemonRepository _repository = repository;

    public async Task<PokemonPageDto> GetPokemonPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var normalizedPage = Math.Max(page, 1);
        var normalizedPageSize = Math.Clamp(pageSize, 1, 50);
        var offset = (normalizedPage - 1) * normalizedPageSize;

        var pokemonPage = await _repository.GetPokemonPageAsync(normalizedPageSize, offset, cancellationToken);
        var pokemon = pokemonPage.Pokemon
            .Select(p => new PokemonSummaryDto(
                p.Id.Value,
                p.Name,
                p.SpriteUrl,
                p.Abilities.Select(a => new PokemonSummaryAbilityDto(a.Name, a.IsHidden)).ToArray()))
            .ToArray();

        return new PokemonPageDto(
            normalizedPage,
            normalizedPageSize,
            pokemonPage.TotalCount,
            pokemon);
    }

    public async Task<PokemonPageDto> SearchPokemonByNameContainsAsync(string name, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new PokemonPageDto(1, Math.Clamp(pageSize, 1, 50), 0, []);
        }

        var normalizedPage = Math.Max(page, 1);
        var normalizedPageSize = Math.Clamp(pageSize, 1, 50);
        var offset = (normalizedPage - 1) * normalizedPageSize;

        var pokemonPage = await _repository.SearchByNameContainsAsync(name.Trim(), normalizedPageSize, offset, cancellationToken);
        var pokemon = pokemonPage.Pokemon
            .Select(p => new PokemonSummaryDto(
                p.Id.Value,
                p.Name,
                p.SpriteUrl,
                p.Abilities.Select(a => new PokemonSummaryAbilityDto(a.Name, a.IsHidden)).ToArray()))
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

        var pokemon = await _repository.GetByNameOrIdAsync(nameOrId.Trim(), cancellationToken);
        if (pokemon is null)
        {
            return null;
        }

        return new PokemonDetailDto(
            pokemon.Id.Value,
            pokemon.Name,
            pokemon.Height,
            pokemon.Weight,
            pokemon.BaseExperience,
            pokemon.SpriteUrl,
            pokemon.ShinySpriteUrl,
            pokemon.Types.Select(t => t.Name).ToArray(),
            pokemon.Abilities.Select(a => new PokemonAbilityDto(a.Name, a.IsHidden)).ToArray(),
            pokemon.BaseStats.Select(s => new PokemonBaseStatDto(s.Name, s.Value)).ToArray());
    }
}
