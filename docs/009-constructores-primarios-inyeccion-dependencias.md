# 009 - Constructores primarios para inyección de dependencias

## Objetivo del cambio
Estandarizar el patrón de inyección de dependencias con constructores primarios en C# 12, evitando el uso directo de parámetros de constructor en métodos y usando solo campos `readonly` con prefijo `_`.

## Capas afectadas
- **Web**: `PokemonController` ahora asigna `IPokemonQueryService` a `_service`.
- **Application**: `PokemonQueryService` ahora asigna `IPokemonRepository` a `_repository`.
- **Infrastructure**:
  - `PokeApiPokemonRepository` ahora asigna `IPokeApiClient` a `_client`.
  - `PokeApiClient` ahora asigna `HttpClient` a `_httpClient`.

## Decisiones técnicas
- Se mantiene el constructor primario para conservar sintaxis moderna de C# 12.
- Se agrega un campo `readonly` por dependencia para evitar referencias directas a parámetros primarios dentro de los métodos.
- Se evita introducir cambios de comportamiento funcional; el ajuste es estructural y de consistencia.

## Impacto arquitectónico
- No cambia la dirección de dependencias entre capas.
- Se mantiene el acceso a datos exclusivamente por PokeAPI mediante infraestructura.
- Se refuerza la cohesión interna de clases al centralizar el uso de dependencias en campos privados inmutables.

## Validación Clean Architecture + DDD + SOLID
- **Clean Architecture**: sin cambios en fronteras ni dependencias entre capas.
- **DDD**: el modelo de dominio no se ve afectado por detalles de DI o transporte HTTP.
- **SOLID**:
  - **S**: cada clase mantiene su responsabilidad actual.
  - **O**: el patrón de DI queda consistente para futuras extensiones.
  - **L/I**: no se alteran contratos públicos ni interfaces.
  - **D**: se preserva la inversión de dependencias con uso de abstracciones.

## Versión asociada
`0.1.8`
