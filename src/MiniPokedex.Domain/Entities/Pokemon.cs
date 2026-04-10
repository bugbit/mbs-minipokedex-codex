using MiniPokedex.Domain.ValueObjects;

namespace MiniPokedex.Domain.Entities;

public sealed class Pokemon
{
    public Pokemon(
        PokemonId id,
        string name,
        int height,
        int weight,
        int baseExperience,
        string spriteUrl,
        string? shinySpriteUrl,
        IReadOnlyCollection<PokemonType> types)
        : this(id, name, height, weight, baseExperience, spriteUrl, shinySpriteUrl, types, [], [])
    {
    }

    public Pokemon(
        PokemonId id,
        string name,
        int height,
        int weight,
        int baseExperience,
        string spriteUrl,
        string? shinySpriteUrl,
        IReadOnlyCollection<PokemonType> types,
        IReadOnlyCollection<PokemonAbility> abilities,
        IReadOnlyCollection<PokemonBaseStat> baseStats)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("El nombre del Pokémon es obligatorio.", nameof(name));
        }

        Id = id;
        Name = name.Trim().ToLowerInvariant();
        Height = height;
        Weight = weight;
        BaseExperience = baseExperience;
        SpriteUrl = spriteUrl;
        ShinySpriteUrl = shinySpriteUrl;
        Types = types;
        Abilities = abilities;
        BaseStats = baseStats;
    }

    public PokemonId Id { get; }
    public string Name { get; }
    public int Height { get; }
    public int Weight { get; }
    public int BaseExperience { get; }
    public string SpriteUrl { get; }
    public string? ShinySpriteUrl { get; }
    public IReadOnlyCollection<PokemonType> Types { get; }
    public IReadOnlyCollection<PokemonAbility> Abilities { get; }
    public IReadOnlyCollection<PokemonBaseStat> BaseStats { get; }
}

public sealed record PokemonAbility(string Name, bool IsHidden);

public sealed record PokemonBaseStat(string Name, int Value);
