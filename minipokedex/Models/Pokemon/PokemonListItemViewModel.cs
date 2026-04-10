namespace minipokedex.Models.Pokemon;

public sealed record PokemonListItemViewModel(
    int Id,
    string Name,
    string SpriteUrl,
    IReadOnlyCollection<PokemonAbilityListItemViewModel> Abilities);

public sealed record PokemonAbilityListItemViewModel(string Name, bool IsHidden);
