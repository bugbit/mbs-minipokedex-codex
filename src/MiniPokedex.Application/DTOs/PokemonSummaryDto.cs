namespace MiniPokedex.Application.DTOs;

public sealed record PokemonSummaryDto(
    int Id,
    string Name,
    string SpriteUrl,
    IReadOnlyCollection<PokemonSummaryAbilityDto> Abilities);

public sealed record PokemonSummaryAbilityDto(string Name, bool IsHidden);

public sealed record PokemonPageDto(
    int Page,
    int PageSize,
    int TotalCount,
    IReadOnlyCollection<PokemonSummaryDto> Pokemon);
