using System.Net;
using System.Net.Http.Json;
using MiniPokedex.Infrastructure.Dtos;

namespace MiniPokedex.Infrastructure.Clients;

public sealed class PokeApiClient(HttpClient httpClient) : IPokeApiClient
{
    public Task<PokeApiPokemonListResponse?> GetPokemonListAsync(int limit, int offset, CancellationToken cancellationToken = default) =>
        httpClient.GetFromJsonAsync<PokeApiPokemonListResponse>($"pokemon?limit={limit}&offset={offset}", cancellationToken);

    public async Task<PokeApiPokemonDetailResponse?> GetPokemonByNameOrIdAsync(string nameOrId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<PokeApiPokemonDetailResponse>($"pokemon/{nameOrId.ToLowerInvariant()}", cancellationToken);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}
