using System.Net;
using System.Net.Http.Json;
using MiniPokedex.Infrastructure.Dtos;

namespace MiniPokedex.Infrastructure.Clients;

public sealed class PokeApiClient(HttpClient httpClient) : IPokeApiClient
{
    private readonly HttpClient _httpClient = httpClient;

    public Task<PokeApiPokemonListResponse?> GetPokemonListAsync(int limit, int offset, CancellationToken cancellationToken = default) =>
        _httpClient.GetFromJsonAsync<PokeApiPokemonListResponse>($"pokemon?limit={limit}&offset={offset}", cancellationToken);

    public async Task<PokeApiPokemonDetailResponse?> GetPokemonByNameOrIdAsync(string nameOrId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<PokeApiPokemonDetailResponse>($"pokemon/{nameOrId.ToLowerInvariant()}", cancellationToken);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}
