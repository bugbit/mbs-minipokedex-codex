# 010 - Habilidades en listado principal

## Objetivo del cambio
Mostrar en la página principal de Pokémon las habilidades de cada elemento del listado.

## Capas afectadas
- **Application**
  - `PokemonSummaryDto` ahora incluye `Abilities` para transportar la información necesaria hacia presentación.
  - `PokemonQueryService` mapea las habilidades del dominio al DTO de resumen.
- **Web (ASP.NET Core MVC)**
  - `PokemonListItemViewModel` agrega `Abilities`.
  - `PokemonController` mapea habilidades del DTO al ViewModel.
  - `Views/Pokemon/Index.cshtml` renderiza habilidades como badges por tarjeta.

## Decisiones técnicas
- Se reutiliza el flujo existente de infraestructura que ya obtiene detalles por Pokémon (incluyendo habilidades) desde PokeAPI.
- Se evita duplicar llamadas HTTP o acoplar la vista a DTOs externos.
- La lógica de transformación permanece fuera del controlador y de la vista, respetando responsabilidades.

## Impacto arquitectónico
- **Clean Architecture**: dependencias mantienen dirección hacia dentro; la vista consume únicamente ViewModels.
- **DDD**: el dominio continúa como fuente de verdad (`Pokemon.Abilities`), sin contaminación de contratos HTTP en capas internas.
- **SOLID**:
  - **S**: cada capa mantiene responsabilidad única (consulta, mapeo, presentación).
  - **O**: el DTO de resumen se extiende sin romper flujo existente.
  - **D**: controlador depende de abstracción `IPokemonQueryService`.

## Validación de Clean Architecture + DDD + SOLID
El cambio preserva separación de capas, encapsula acceso a PokeAPI en infraestructura existente y mantiene modelos de presentación separados de dominio/infraestructura.

## Versión asociada
- `minipokedex`: **0.1.9**
- `MiniPokedex.Application`: **0.1.3**
