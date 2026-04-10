namespace MiniPokedex.Domain.ValueObjects;

public readonly record struct PokemonId
{
    public PokemonId(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "El ID del Pokémon debe ser mayor que cero.");
        }

        Value = value;
    }

    public int Value { get; }

    public override string ToString() => Value.ToString();
}
