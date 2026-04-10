using Microsoft.AspNetCore.Mvc;
using MiniPokedex.Application.Abstractions;
using minipokedex.Models.Pokemon;

namespace minipokedex.Controllers;

public sealed class PokemonController(IPokemonQueryService service) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 12, CancellationToken cancellationToken = default)
    {
        var result = await service.GetPokemonPageAsync(page, pageSize, cancellationToken);

        var viewModel = new PokemonIndexViewModel(
            result.Page,
            result.PageSize,
            result.TotalCount,
            result.Pokemon.Select(p => new PokemonListItemViewModel(p.Id, p.Name, p.SpriteUrl)).ToArray());

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string nameOrId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(nameOrId))
        {
            TempData["SearchError"] = "Ingresa un nombre o ID para buscar.";
            return RedirectToAction(nameof(Index));
        }

        var pokemon = await service.GetPokemonAsync(nameOrId, cancellationToken);
        if (pokemon is null)
        {
            TempData["SearchError"] = $"No se encontró ningún Pokémon para \"{nameOrId.Trim()}\".";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Detail), new { nameOrId = pokemon.Name });
    }

    [HttpGet]
    public async Task<IActionResult> Detail(string nameOrId, CancellationToken cancellationToken = default)
    {
        var pokemon = await service.GetPokemonAsync(nameOrId, cancellationToken);
        if (pokemon is null)
        {
            return NotFound();
        }

        return View(new PokemonDetailViewModel(
            pokemon.Id,
            pokemon.Name,
            pokemon.Height,
            pokemon.Weight,
            pokemon.SpriteUrl,
            pokemon.Types));
    }
}
