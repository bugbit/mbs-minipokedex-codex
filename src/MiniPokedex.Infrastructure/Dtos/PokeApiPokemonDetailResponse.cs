using System.Text.Json.Serialization;

namespace MiniPokedex.Infrastructure.Dtos;

public sealed class PokeApiPokemonDetailResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("sprites")]
    public PokeApiSprites Sprites { get; set; } = new();

    [JsonPropertyName("types")]
    public List<PokeApiTypeSlot> Types { get; set; } = [];
}

public sealed class PokeApiSprites
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }

    [JsonPropertyName("other")]
    public PokeApiOtherSprites? Other { get; set; }
}

public sealed class PokeApiOtherSprites
{
    [JsonPropertyName("official-artwork")]
    public PokeApiOfficialArtworkSprites? OfficialArtwork { get; set; }
}

public sealed class PokeApiOfficialArtworkSprites
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }
}

public sealed class PokeApiTypeSlot
{
    [JsonPropertyName("type")]
    public PokeApiType Type { get; set; } = new();
}

public sealed class PokeApiType
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
