namespace minipokedex.Models.Pokemon;

public sealed record PokemonIndexViewModel(
    int Page,
    int PageSize,
    int TotalCount,
    IReadOnlyCollection<PokemonListItemViewModel> Pokemon)
{
    public int TotalPages => TotalCount <= 0 ? 1 : (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
}
