using System.Text.Json.Serialization;

namespace MiniPokedex.Infrastructure.Dtos;

public sealed class PokeApiPokemonListResponse
{
    [JsonPropertyName("results")]
    public List<PokeApiPokemonListItem> Results { get; set; } = [];
}

public sealed class PokeApiPokemonListItem
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
