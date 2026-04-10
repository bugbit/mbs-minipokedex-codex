# 003 - Paginación en página principal

## Objetivo del cambio
Incorporar paginación funcional en la página principal (`/Pokemon/Index`) con información de páginas totales y navegación por números de página.

## Capas afectadas
- **Web (ASP.NET Core MVC)**
  - `PokemonController`
  - `PokemonIndexViewModel`
  - `Views/Pokemon/Index.cshtml`
- **Application**
  - `IPokemonQueryService`
  - `PokemonQueryService`
  - DTO de página (`PokemonPageDto`)
- **Domain**
  - Contrato de repositorio (`IPokemonRepository`) con resultado paginado (`PokemonPageResult`)
- **Infrastructure**
  - `PokeApiPokemonRepository`
  - DTO de lista PokeAPI (`PokeApiPokemonListResponse`) usando `count`

## Decisiones técnicas
- Se usa el campo `count` de la respuesta de PokeAPI para calcular el total de páginas.
- Se encapsula el resultado paginado en DTOs/records específicos para evitar exponer modelos externos a la capa Web.
- Se mantiene el controlador ligero, delegando la normalización de parámetros y mapeo a la capa de aplicación.

## Impacto arquitectónico
- **Clean Architecture**: dependencias mantienen dirección hacia adentro (Web -> Application -> Domain; Infrastructure implementa puertos).
- **DDD**: el puerto de repositorio expresa un resultado de dominio paginado sin detalles de UI ni HTTP.
- **SOLID**:
  - **S**: cada capa mantiene su responsabilidad (UI, caso de uso, acceso externo).
  - **O**: el modelo de paginación permite extender metadatos sin romper controladores.
  - **I/D**: la Web depende de abstracciones de aplicación, no de infraestructura.

## Validación de fuente de datos
- El listado y metadatos de paginación se obtienen exclusivamente desde **PokeAPI** (`https://pokeapi.co/api/v2/`) mediante la infraestructura existente.

## Versión asociada
- `0.1.2`
