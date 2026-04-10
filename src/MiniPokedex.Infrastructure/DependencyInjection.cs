using Microsoft.Extensions.Configuration;
using MiniPokedex.Application.Abstractions;
using MiniPokedex.Application.Services;
using MiniPokedex.Domain.Repositories;
using MiniPokedex.Infrastructure.Clients;
using MiniPokedex.Infrastructure.Options;
using MiniPokedex.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddMiniPokedexInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PokeApiOptions>(configuration.GetSection(PokeApiOptions.SectionName));

        var baseUrl = configuration[$"{PokeApiOptions.SectionName}:{nameof(PokeApiOptions.BaseUrl)}"]
            ?? "https://pokeapi.co/api/v2/";

        services.AddHttpClient<IPokeApiClient, PokeApiClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
            client.Timeout = TimeSpan.FromSeconds(10);
        });

        services.AddScoped<IPokemonRepository, PokeApiPokemonRepository>();
        services.AddScoped<IPokemonQueryService, PokemonQueryService>();

        return services;
    }
}
