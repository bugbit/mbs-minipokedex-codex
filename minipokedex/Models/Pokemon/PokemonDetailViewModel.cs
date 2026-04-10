namespace minipokedex.Models.Pokemon;

public sealed record PokemonDetailViewModel(
    int Id,
    string Name,
    int Height,
    int Weight,
    int BaseExperience,
    string SpriteUrl,
    string? ShinySpriteUrl,
    IReadOnlyCollection<string> Types,
    IReadOnlyCollection<PokemonAbilityViewModel> Abilities,
    IReadOnlyCollection<PokemonBaseStatViewModel> BaseStats);

public sealed record PokemonAbilityViewModel(string Name, bool IsHidden);

public sealed record PokemonBaseStatViewModel(string Name, int Value);
