# 001 - Preparación del repositorio para .NET 10

## Objetivo del cambio

Dejar el repositorio listo para ejecutarse con SDK **.NET 10** de forma consistente en entornos locales.

## Capas afectadas

- **Web/Presentation**: sin cambios funcionales.
- **Application/Domain/Infrastructure**: sin cambios funcionales.
- **Tooling del repositorio**: se añade pin de SDK y mejoras del script de instalación.

## Decisiones técnicas

1. Se agregó `global.json` para fijar `10.0.100` y evitar diferencias de SDK entre entornos.
2. Se mejoró `scripts/setup-dotnet.sh` para:
   - instalar canal `10.0`,
   - verificar versión instalada,
   - evitar duplicar exports en `.bashrc`.
3. Se actualizó `README.md` con pasos mínimos de instalación y verificación.

## Impacto arquitectónico

- No se modifica lógica de negocio ni contratos.
- El cambio solo impacta la preparación del entorno de ejecución.

## Validación Clean Architecture + DDD + SOLID

- **Clean Architecture**: sin violaciones; no se alteran dependencias entre capas.
- **DDD**: sin impacto sobre entidades, value objects o agregados.
- **SOLID**: sin impacto en clases de dominio/aplicación.
- **Fuente de datos**: no se altera la regla de uso exclusivo de PokeAPI.

## Versión asociada

`0.1.0`
