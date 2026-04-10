# 012 - Búsqueda mixta por id o nombre contiene

## Objetivo del cambio
Corregir la búsqueda del listado para que:
- si el término es numérico, consulte un Pokémon por su `id` exacto,
- si el término es texto, mantenga el filtrado por nombre usando `contains`.

## Capas afectadas
- **Application**: `PokemonQueryService` ahora decide la estrategia de búsqueda según el tipo de término.
- **Web (MVC)**: actualización de placeholder/mensaje en la vista de listado para comunicar el comportamiento real.

## Decisiones técnicas
- Se mantiene un único caso de uso público (`SearchPokemonByNameContainsAsync`) para no introducir complejidad innecesaria en el controlador.
- La detección numérica se resuelve con `int.TryParse` en Application.
- Para búsqueda numérica se reutiliza el puerto de dominio existente `GetByNameOrIdAsync`, evitando duplicar contratos.
- Se conserva la paginación: en búsqueda numérica el total es `1` (si existe) y solo hay resultados en página `1`.

## Impacto arquitectónico
- **Clean Architecture**: la decisión de búsqueda vive en Application; la vista solo presenta datos.
- **DDD**: se reutilizan entidades/VOs de dominio sin acoplar la capa interna a DTOs HTTP.
- **SOLID**:
  - **S**: Controller permanece ligero; servicio concentra la lógica de consulta.
  - **O**: se extiende comportamiento de búsqueda sin romper contratos públicos del controlador.
  - **L/I/D**: se mantiene dependencia sobre `IPokemonRepository` y contratos existentes.

## Validación de reglas
- Fuente de datos: se mantiene **exclusivamente PokeAPI** vía infraestructura existente.
- Contrato: no se altera alineación con `context/pokeapi-openapi.json`.
- Sin tecnologías adicionales ni dependencias nuevas.

## Versión asociada
- `0.1.11`
