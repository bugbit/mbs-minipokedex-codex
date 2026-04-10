# 005 - Fix visualización de imágenes en listado de Pokémon

## Objetivo del cambio
Mejorar la calidad visual de las imágenes de Pokémon en las tarjetas del listado principal, evitando que se muestren sprites pequeños cuando exista arte oficial de mayor resolución.

## Capas afectadas
- **Infrastructure**: ampliación de DTOs de PokeAPI y mapeo de imagen preferente.
- **Web (Presentation)**: ajuste de renderizado y estilos CSS de tarjetas.

## Decisiones técnicas
1. Se extiende `PokeApiPokemonDetailResponse` para soportar el nodo `sprites.other.official-artwork.front_default` del contrato de PokeAPI.
2. En `PokeApiPokemonRepository`, se prioriza `official-artwork` y se mantiene fallback a `front_default` para robustez.
3. Se extrae el estilo inline de la vista a `site.css` con clase reutilizable `pokemon-card-image`.

## Impacto arquitectónico
- Se mantiene la separación de responsabilidades:
  - infraestructura encapsula parsing/mapeo de contrato externo;
  - web solo presenta datos y estilos.
- No se introducen dependencias nuevas ni se altera el flujo de casos de uso.

## Validación Clean Architecture + DDD + SOLID
- **Clean Architecture**: dependencias continúan apuntando hacia adentro; solo infraestructura conoce detalles de PokeAPI.
- **DDD**: el dominio sigue sin contaminarse con DTOs externos; solo recibe `SpriteUrl` ya resuelto.
- **SOLID**:
  - **S**: cada capa mantiene una responsabilidad única.
  - **O**: se extiende DTO/mapeo sin romper contratos existentes.
  - **L/I/D**: no se alteran contratos de repositorio ni inversión de dependencias.

## Uso exclusivo de PokeAPI
La fuente de datos se mantiene exclusivamente en `https://pokeapi.co/api/v2/`, reutilizando el contrato existente.

## Versión asociada
`0.1.4`
