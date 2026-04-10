namespace minipokedex.Models.Pokemon;

public sealed record PokemonIndexViewModel(int Page, int PageSize, IReadOnlyCollection<PokemonListItemViewModel> Pokemon);
