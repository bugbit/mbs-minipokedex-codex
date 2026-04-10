# Changelog

Todos los cambios notables de este proyecto se documentarán en este archivo.

El formato está basado en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/),
y este proyecto adhiere a [Semantic Versioning](https://semver.org/lang/es/).

## [0.1.12] - 2026-04-10
### Added
- La página principal incluye selector para alternar entre vista tipo `Cards` y vista tipo `Lista`.

### Changed
- La acción `Index` preserva y valida el parámetro `viewMode` (`card`/`list`) para mantener el modo durante búsqueda y paginación.
- Se agrega renderizado condicional en la vista principal y estilos para tabla/listado compacto.
- Se documenta el cambio en `/docs/013-modo-lista-y-card-en-pagina-principal.md`.

## [0.1.11] - 2026-04-10
### Changed
- La búsqueda del listado ahora interpreta términos numéricos como búsqueda por identificador de Pokémon (`id`) y mantiene búsqueda por contiene cuando el término es texto.
- Se ajusta el mensaje/placeholder de búsqueda en la vista para reflejar el comportamiento mixto (número exacto o nombre contiene).
- Se documenta el ajuste en `/docs/012-busqueda-mixta-id-o-nombre-contiene.md`.

## [0.1.10] - 2026-04-10
### Changed
- Se alinea el estilo de habilidades del listado principal con el detalle: badges `rounded-pill`, color primario para habilidad normal y secundario para habilidad oculta.
- El flujo Application/Web ahora preserva `IsHidden` por habilidad en el resumen para permitir renderizado consistente entre listado y detalle.
- Se documenta el ajuste en `/docs/011-estilo-habilidades-listado-consistente-con-detalle.md`.

## [0.1.9] - 2026-04-10
### Changed
- Se muestran las habilidades de cada Pokémon directamente en las tarjetas del listado principal.
- Se extiende el flujo Application/Web para transportar y renderizar `Abilities` desde el dominio hasta la vista de índice.
- Se documenta el cambio técnico en `/docs/010-habilidades-en-listado-principal.md`.

## [0.1.8] - 2026-04-10
### Changed
- Se estandariza el uso de constructores primarios para inyección de dependencias asignando cada parámetro a un campo `readonly` con prefijo `_` en Web/Application/Infrastructure.
- Se agrega la regla de constructores primarios en `CLAUDE.md` para mantener el criterio consistente en cambios futuros.
- Se documenta el cambio técnico en `/docs/009-constructores-primarios-inyeccion-dependencias.md`.

## [0.1.7] - 2026-04-10
### Changed
- Se rediseña la vista de detalle de Pokémon para alinearla con el layout solicitado (cabecera, badges de tipo, bloque de métricas, habilidades y estadísticas base con barras visuales).
- Se amplía el flujo de detalle en Domain/Application/Infrastructure para incluir `base_experience`, `abilities`, `stats` y sprite shiny desde PokeAPI.
- Se agrega documentación técnica del cambio en `/docs/008-rediseno-detalle-pokemon.md`.

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
