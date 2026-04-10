using MiniPokedex.Domain.ValueObjects;

namespace MiniPokedex.Domain.Entities;

public sealed class Pokemon
{
    public Pokemon(
        PokemonId id,
        string name,
        int height,
        int weight,
        string spriteUrl,
        IReadOnlyCollection<PokemonType> types)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("El nombre del Pokémon es obligatorio.", nameof(name));
        }

        Id = id;
        Name = name.Trim().ToLowerInvariant();
        Height = height;
        Weight = weight;
        SpriteUrl = spriteUrl;
        Types = types;
    }

    public PokemonId Id { get; }
    public string Name { get; }
    public int Height { get; }
    public int Weight { get; }
    public string SpriteUrl { get; }
    public IReadOnlyCollection<PokemonType> Types { get; }
}
