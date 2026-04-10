# 002 - Fix de compilación por `IConfiguration` en infraestructura

## Objetivo del cambio
Corregir el error de compilación `CS0246` en `DependencyInjection.cs` agregando la importación explícita del namespace de configuración.

## Capas afectadas
- **Infrastructure**: extensión de registro de dependencias.

## Decisiones técnicas
- Se añadió `using Microsoft.Extensions.Configuration;` para resolver `IConfiguration` de forma explícita.
- Se mantuvo la responsabilidad de wiring de infraestructura sin mover lógica a otras capas.

## Impacto arquitectónico
- No cambia comportamiento funcional.
- Mantiene la dirección de dependencias de Clean Architecture.

## Validación Clean Architecture + DDD + SOLID
- **Clean Architecture**: sin cambios en límites de capa.
- **DDD**: sin impacto al modelo de dominio.
- **SOLID**: se conserva SRP en la clase de composición.

## Contrato PokeAPI
- No se altera el contrato ni la fuente de datos (`https://pokeapi.co/api/v2/`).

## Versión asociada
- `0.1.1` (fix de compilación).
