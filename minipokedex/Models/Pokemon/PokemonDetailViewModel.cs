namespace minipokedex.Models.Pokemon;

public sealed record PokemonDetailViewModel(
    int Id,
    string Name,
    int Height,
    int Weight,
    string SpriteUrl,
    IReadOnlyCollection<string> Types);
