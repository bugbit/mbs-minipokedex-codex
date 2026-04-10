namespace MiniPokedex.Domain.ValueObjects;

public sealed record PokemonType
{
    public PokemonType(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("El tipo de Pokémon es obligatorio.", nameof(name));
        }

        Name = name.Trim().ToLowerInvariant();
    }

    public string Name { get; }
}
