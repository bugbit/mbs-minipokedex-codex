# 008 - Rediseño de página de detalle Pokémon

## Objetivo del cambio
Actualizar la vista `Detail` para que se asemeje al diseño de referencia: cabecera con tipos, imagen destacada, métricas, habilidades y estadísticas base con barras visuales.

## Capas afectadas
- **Web**: rediseño de `Views/Pokemon/Detail.cshtml`, nuevos estilos en `wwwroot/css/site.css`, ampliación de `PokemonDetailViewModel` y mapeo en `PokemonController`.
- **Application**: ampliación de `PokemonDetailDto` y mapeo en `PokemonQueryService` para exponer estadísticas, habilidades, sprite shiny y experiencia base.
- **Domain**: ampliación de `Pokemon` para incluir `BaseExperience`, `ShinySpriteUrl`, `Abilities` y `BaseStats`.
- **Infrastructure**: ampliación de DTO de PokeAPI y mapeo en `PokeApiPokemonRepository` para poblar los nuevos campos desde `https://pokeapi.co/api/v2/`.

## Decisiones técnicas
- Se mantuvo el controlador delgado y la lógica de composición de UI en view model.
- Se encapsuló el consumo de nuevos campos de PokeAPI en infraestructura, sin exponer DTOs externos en Web.
- Se añadió alternancia de sprite normal/shiny en la vista con JavaScript mínimo y desacoplado.

## Impacto arquitectónico
- Se preserva la dirección de dependencias de Clean Architecture (Web → Application → Domain, Infrastructure implementa puertos).
- El dominio sigue sin depender de detalles HTTP.
- Se mantiene separación entre modelos externos de PokeAPI, dominio y view models.

## Validación Clean Architecture + DDD + SOLID
- **Clean Architecture**: sin violaciones de dependencias entre capas.
- **DDD**: el agregado `Pokemon` concentra datos del detalle y mantiene invariantes simples.
- **SOLID**:
  - **S**: cada clase mantiene una responsabilidad (mapeo, transporte, presentación).
  - **O**: se extendió DTO/entidad sin modificar contratos externos de listado.
  - **L/I**: contratos (`IPokemonRepository`, `IPokemonQueryService`) se mantienen sustituibles y específicos.
  - **D**: Web y Application dependen de abstracciones existentes.

## Versión asociada
`0.1.7`
