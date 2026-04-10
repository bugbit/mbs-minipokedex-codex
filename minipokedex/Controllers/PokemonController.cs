using Microsoft.AspNetCore.Mvc;
using MiniPokedex.Application.Abstractions;
using minipokedex.Models.Pokemon;

namespace minipokedex.Controllers;

public sealed class PokemonController(IPokemonQueryService service) : Controller
{
    private readonly IPokemonQueryService _service = service;

    [HttpGet]
    public async Task<IActionResult> Index(
        string? searchTerm,
        int page = 1,
        int pageSize = 12,
        CancellationToken cancellationToken = default)
    {
        var normalizedSearchTerm = string.IsNullOrWhiteSpace(searchTerm) ? null : searchTerm.Trim();
        var result = normalizedSearchTerm is null
            ? await _service.GetPokemonPageAsync(page, pageSize, cancellationToken)
            : await _service.SearchPokemonByNameContainsAsync(normalizedSearchTerm, page, pageSize, cancellationToken);

        var viewModel = new PokemonIndexViewModel(
            result.Page,
            result.PageSize,
            result.TotalCount,
            normalizedSearchTerm,
            result.Pokemon.Select(p => new PokemonListItemViewModel(p.Id, p.Name, p.SpriteUrl)).ToArray());

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(string nameOrId, CancellationToken cancellationToken = default)
    {
        var pokemon = await _service.GetPokemonAsync(nameOrId, cancellationToken);
        if (pokemon is null)
        {
            return NotFound();
        }

        return View(new PokemonDetailViewModel(
            pokemon.Id,
            pokemon.Name,
            pokemon.Height,
            pokemon.Weight,
            pokemon.BaseExperience,
            pokemon.SpriteUrl,
            pokemon.ShinySpriteUrl,
            pokemon.Types,
            pokemon.Abilities.Select(a => new PokemonAbilityViewModel(a.Name, a.IsHidden)).ToArray(),
            pokemon.BaseStats.Select(s => new PokemonBaseStatViewModel(s.Name, s.Value)).ToArray()));
    }
}
