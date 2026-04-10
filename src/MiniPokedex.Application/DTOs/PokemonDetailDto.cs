namespace MiniPokedex.Application.DTOs;

public sealed record PokemonDetailDto(
    int Id,
    string Name,
    int Height,
    int Weight,
    string SpriteUrl,
    IReadOnlyCollection<string> Types);
