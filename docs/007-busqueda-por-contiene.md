# 007 - Búsqueda por contiene

## Objetivo del cambio
Implementar búsqueda por nombre usando criterio **contiene** para que el usuario pueda filtrar Pokémon con coincidencias parciales desde el listado.

## Capas afectadas
- **Domain**
  - `IPokemonRepository`: nuevo contrato `SearchByNameContainsAsync`.
- **Application**
  - `IPokemonQueryService`: nuevo caso de uso `SearchPokemonByNameContainsAsync`.
  - `PokemonQueryService`: implementación de paginación para búsqueda por contiene.
- **Infrastructure**
  - `PokeApiPokemonRepository`: implementación de búsqueda parcial usando listado de PokeAPI + detalle por página.
- **Web**
  - `PokemonController`: `Index` ahora acepta `searchTerm` y usa el caso de uso adecuado.
  - `PokemonIndexViewModel` y vista `Index`: soporte de término de búsqueda y paginación preservando filtro.

## Decisiones técnicas
- Se usa `pokemon?limit=2000&offset=0` para obtener nombres desde PokeAPI y aplicar `Contains(..., OrdinalIgnoreCase)`.
- Se mantiene el detalle con búsqueda exacta (`Detail`), y el listado usa coincidencia parcial.
- La vista mantiene el término de búsqueda en los links de paginación.

## Impacto arquitectónico
- Dependencias siguen apuntando hacia adentro (Web -> Application -> Domain, Infrastructure implementa puertos).
- El acceso HTTP continúa encapsulado en infraestructura.
- No se mezclan DTOs externos con modelos de vista.

## Validación Clean Architecture + DDD + SOLID
- **Clean Architecture**: cada capa mantiene su responsabilidad.
- **DDD**: repositorio de dominio define contrato; infraestructura implementa.
- **SOLID**:
  - **S**: búsqueda parcial encapsulada en método específico.
  - **O**: extensión por nuevo caso de uso sin romper el existente.
  - **I/D**: controladores dependen de abstracciones (`IPokemonQueryService`).

## Fuente de datos
- Se mantiene **PokeAPI** como única fuente, alineado al contrato existente.

## Versión asociada
- `0.1.6`
