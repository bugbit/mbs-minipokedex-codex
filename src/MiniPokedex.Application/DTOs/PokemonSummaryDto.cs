namespace MiniPokedex.Application.DTOs;

public sealed record PokemonSummaryDto(
    int Id,
    string Name,
    string SpriteUrl,
    IReadOnlyCollection<string> Abilities);

public sealed record PokemonPageDto(
    int Page,
    int PageSize,
    int TotalCount,
    IReadOnlyCollection<PokemonSummaryDto> Pokemon);
