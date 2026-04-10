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

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }

    [JsonPropertyName("sprites")]
    public PokeApiSprites Sprites { get; set; } = new();

    [JsonPropertyName("types")]
    public List<PokeApiTypeSlot> Types { get; set; } = [];

    [JsonPropertyName("abilities")]
    public List<PokeApiAbilitySlot> Abilities { get; set; } = [];

    [JsonPropertyName("stats")]
    public List<PokeApiStatSlot> Stats { get; set; } = [];
}

public sealed class PokeApiSprites
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string? FrontShiny { get; set; }

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

    [JsonPropertyName("front_shiny")]
    public string? FrontShiny { get; set; }
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

public sealed class PokeApiAbilitySlot
{
    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonPropertyName("ability")]
    public PokeApiAbility Ability { get; set; } = new();
}

public sealed class PokeApiAbility
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

public sealed class PokeApiStatSlot
{
    [JsonPropertyName("base_stat")]
    public int BaseStat { get; set; }

    [JsonPropertyName("stat")]
    public PokeApiStat Stat { get; set; } = new();
}

public sealed class PokeApiStat
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
