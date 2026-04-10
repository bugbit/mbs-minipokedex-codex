namespace MiniPokedex.Application.DTOs;

public sealed record PokemonDetailDto(
    int Id,
    string Name,
    int Height,
    int Weight,
    int BaseExperience,
    string SpriteUrl,
    string? ShinySpriteUrl,
    IReadOnlyCollection<string> Types,
    IReadOnlyCollection<PokemonAbilityDto> Abilities,
    IReadOnlyCollection<PokemonBaseStatDto> BaseStats);

public sealed record PokemonAbilityDto(string Name, bool IsHidden);

public sealed record PokemonBaseStatDto(string Name, int Value);
