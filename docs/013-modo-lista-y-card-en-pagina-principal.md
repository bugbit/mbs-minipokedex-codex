# 013 - Modo lista y modo card en la página principal

## Objetivo del cambio
Agregar en la página principal de Pokémon una opción para alternar entre visualización en **cards** y visualización en **lista**, preservando búsqueda y paginación.

## Capas afectadas
- **Web (ASP.NET Core MVC)**
  - `PokemonController`: normalización y persistencia del parámetro `viewMode`.
  - `PokemonIndexViewModel`: estado de vista seleccionada (`card` / `list`).
  - `Views/Pokemon/Index.cshtml`: selector de modo y renderizado condicional de layout.
  - `wwwroot/css/site.css`: estilos para la vista de lista.

## Decisiones técnicas
- Se añadió `viewMode` como query param opcional en `Index`.
- Se centralizó la validación con `NormalizeViewMode`, aceptando solo `card` y `list` (fallback a `card`).
- Se mantuvo el mismo modelo de datos y la misma fuente (PokeAPI) sin cambios en Application/Infrastructure/Domain.
- La paginación y búsqueda conservan el modo seleccionado mediante `asp-route-viewMode`.

## Impacto arquitectónico
- **Clean Architecture**: cambio localizado en presentación, sin romper dependencias hacia capas internas.
- **DDD**: sin contaminación del dominio; el modo de renderizado es una preocupación de UI.
- **SOLID**:
  - **S**: controlador solo coordina parámetros de entrada y delega consultas.
  - **O**: la vista se extiende con un segundo modo sin alterar contratos de Application.
  - **D**: se mantiene inversión de dependencias vía `IPokemonQueryService`.

## Validación de reglas
- Se mantiene **PokeAPI** como única fuente de datos.
- No se introducen tecnologías externas ni dependencias nuevas.
- Se preserva separación DTO externo / dominio / view models.

## Versión asociada
- `0.1.12`
