# Changelog

Todos los cambios notables de este proyecto se documentarán en este archivo.

El formato está basado en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/),
y este proyecto adhiere a [Semantic Versioning](https://semver.org/lang/es/).

## [0.1.6] - 2026-04-10
### Changed
- La búsqueda del listado ahora funciona por **contiene** sobre nombre (`searchTerm`) en lugar de requerir coincidencia exacta.
- Se mantiene la paginación cuando hay término de búsqueda, preservando `searchTerm` entre páginas.

### Fixed
- Se elimina el flujo de redirección a detalle para búsqueda general y se muestran resultados filtrados directamente en el listado.
- Documentación técnica del ajuste en `/docs/007-busqueda-por-contiene.md`.

## [0.1.5] - 2026-04-10
### Fixed
- Se corrige el flujo de búsqueda en `PokemonController` agregando una acción `Search` que valida entrada vacía y evita respuestas 404 directas al usuario.
- Cuando no hay resultados, la búsqueda vuelve al listado con mensaje de error en la UI para mantener una experiencia consistente.
- Documentación técnica del ajuste en `/docs/006-fix-flujo-busqueda.md`.

## [0.1.4] - 2026-04-10
### Fixed
- Se mejora la visualización de imágenes en tarjetas del listado al priorizar `sprites.other.official-artwork.front_default` de PokeAPI y usar `sprites.front_default` como fallback.
- Se ajusta el estilo CSS de la imagen en tarjetas para mantener tamaño consistente y fondo neutro en el listado.
- Documentación técnica del ajuste en `/docs/005-fix-imagenes-pokemon-listado.md`.

## [0.1.3] - 2026-04-10
### Fixed
- Se desactiva la generación de `apphost.exe` en `minipokedex.csproj` (`UseAppHost=false`) para evitar el error `MSB4018 CreateAppHost` por acceso denegado al archivo `obj/Debug/net10.0/apphost.exe` en entornos Windows bloqueados.
- Documentación técnica del ajuste en `/docs/004-fix-createapphost-access-denied.md`.

## [0.1.2] - 2026-04-10
### Added
- Paginación real en la vista principal con navegación por números de página, estado activo y botones Anterior/Siguiente deshabilitados cuando corresponde.

### Changed
- Consulta de listado de Pokémon ahora devuelve también `TotalCount` para calcular el total de páginas desde la respuesta oficial de PokeAPI.
- Ajustes en modelo de vista y controlador para mantener la lógica de paginación fuera de la vista y respetar separación de responsabilidades.
- Documentación técnica del cambio en `/docs/003-paginacion-pagina-principal.md`.

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
