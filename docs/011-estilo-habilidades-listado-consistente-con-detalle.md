# 011 - Estilo de habilidades del listado consistente con detalle

## Objetivo del cambio
Alinear la visualización de habilidades en la página principal con el mismo estilo visual y semántico usado en la vista de detalle.

## Capas afectadas
- **Application**
  - `PokemonSummaryDto` cambia `Abilities` para incluir nombre y bandera `IsHidden`.
  - Se agrega `PokemonSummaryAbilityDto`.
  - `PokemonQueryService` mapea `IsHidden` desde dominio.
- **Web (ASP.NET Core MVC)**
  - `PokemonListItemViewModel` incorpora colección tipada con `IsHidden`.
  - `PokemonController` transforma DTOs de habilidades a ViewModel.
  - `Views/Pokemon/Index.cshtml` renderiza badges con el mismo patrón de la vista de detalle.

## Decisiones técnicas
- Se evita lógica de estado en la vista que dependa de strings; se usa modelo tipado para `IsHidden`.
- Se reutiliza el contrato de dominio (`Pokemon.Abilities`) sin acoplar presentación a infraestructura.
- Se mantiene el cambio mínimo para cumplir consistencia visual requerida.

## Impacto arquitectónico
- **Clean Architecture**: la presentación recibe datos ya transformados desde Application.
- **DDD**: `IsHidden` pertenece al concepto de habilidad en el dominio y se preserva en el mapeo.
- **SOLID**:
  - **S**: cada capa conserva su responsabilidad.
  - **O**: extensión del DTO sin alterar contratos externos de infraestructura.
  - **D**: controlador sigue dependiendo de `IPokemonQueryService`.

## Validación de Clean Architecture + DDD + SOLID
Se mantiene separación de capas, uso exclusivo de PokeAPI y mapeo explícito entre Domain/Application/Web.

## Versión asociada
- `minipokedex`: **0.1.10**
- `MiniPokedex.Application`: **0.1.4**
