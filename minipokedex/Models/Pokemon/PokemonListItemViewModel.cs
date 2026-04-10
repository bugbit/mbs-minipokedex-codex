namespace minipokedex.Models.Pokemon;

public sealed record PokemonListItemViewModel(
    int Id,
    string Name,
    string SpriteUrl,
    IReadOnlyCollection<string> Abilities);
