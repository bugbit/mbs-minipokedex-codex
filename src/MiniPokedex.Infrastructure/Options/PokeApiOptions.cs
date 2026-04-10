namespace MiniPokedex.Infrastructure.Options;

public sealed class PokeApiOptions
{
    public const string SectionName = "PokeApi";
    public string BaseUrl { get; set; } = "https://pokeapi.co/api/v2/";
}
