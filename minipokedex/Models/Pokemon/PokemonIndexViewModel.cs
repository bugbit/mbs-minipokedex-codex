namespace minipokedex.Models.Pokemon;

public sealed record PokemonIndexViewModel(
    int Page,
    int PageSize,
    int TotalCount,
    string? SearchTerm,
    string ViewMode,
    IReadOnlyCollection<PokemonListItemViewModel> Pokemon)
{
    public int TotalPages => TotalCount <= 0 ? 1 : (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
    public bool IsCardView => ViewMode == "card";
    public bool IsListView => ViewMode == "list";
}
