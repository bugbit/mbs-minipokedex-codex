# 001 - Código base completo para Pokedev

## Objetivo del cambio
Crear el código base funcional de MiniPokedex en ASP.NET Core MVC con .NET 10, usando exclusivamente PokeAPI como fuente de datos.

## Capas afectadas
- **Domain**: entidades, value objects y contrato de repositorio.
- **Application**: servicio de consulta y DTOs de aplicación.
- **Infrastructure**: cliente HTTP PokeAPI, DTOs externos y repositorio concreto.
- **Web**: controlador MVC, view models, vistas y wiring de DI.

## Decisiones técnicas
- Se centralizó el acceso a PokeAPI en `PokeApiClient`.
- Se aplicó mapeo explícito `DTO externo -> Dominio -> DTO aplicación -> ViewModel`.
- Se configuró `HttpClient` con `BaseUrl` desde configuración (`appsettings.json`).
- Se mantuvo el controlador ligero, delegando lógica en `IPokemonQueryService`.

## Impacto arquitectónico
- Se establece base de Clean Architecture con dependencias hacia adentro:
  - Application -> Domain
  - Infrastructure -> Application/Domain
  - Web -> Application/Infrastructure
- Se evita contaminar el dominio con detalles HTTP o de UI.

## Validación Clean Architecture + DDD + SOLID
- **Clean Architecture**: capas separadas y responsabilidades aisladas.
- **DDD**: `Pokemon` como entidad, `PokemonId` y `PokemonType` como value objects, repositorio en dominio.
- **SOLID**:
  - **S**: clases con responsabilidad única.
  - **O**: extensible agregando nuevos repositorios/servicios sin modificar el dominio.
  - **L**: `IPokemonRepository` e `IPokemonQueryService` reemplazables.
  - **I**: interfaces pequeñas enfocadas en consultas.
  - **D**: inversión de dependencias en Application y Web.

## Contrato PokeAPI
- Fuente única: `https://pokeapi.co/api/v2/`.
- Contrato de referencia considerado: `context/pokeapi-openapi.json`.

## Versión asociada
- `0.1.0` (alta inicial funcional de la base Pokedev).
