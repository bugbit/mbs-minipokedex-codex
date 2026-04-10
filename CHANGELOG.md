# Changelog

Todos los cambios notables de este proyecto se documentarán en este archivo.

El formato está basado en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/),
y este proyecto adhiere a [Semantic Versioning](https://semver.org/lang/es/).

## [0.1.1] - 2026-04-10
### Fixed
- Corrección de `CS0246` en infraestructura al importar explícitamente `Microsoft.Extensions.Configuration` para `IConfiguration`.
- Documentación del fix en `/docs/002-fix-iconfiguration-infra.md`.

## [0.1.0] - 2026-04-10
### Added
- Estructura base en capas `Domain`, `Application`, `Infrastructure` y `Web` para MiniPokedex.
- Integración con PokeAPI mediante `HttpClient` centralizado en infraestructura.
- Casos de uso de consulta de Pokémon y repositorio de dominio.
- Controlador MVC `PokemonController` con vistas de listado, búsqueda y detalle.
- Modelos de vista dedicados para separar dominio/aplicación de presentación.
- Documentación arquitectónica del cambio en `/docs/001-codigo-base-pokedev.md`.
