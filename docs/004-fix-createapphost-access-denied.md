# 004 - Fix MSB4018 CreateAppHost (Access denied)

## Objetivo del cambio
Corregir el fallo de compilación reportado en Windows:
- `MSB4018 The "CreateAppHost" task failed unexpectedly`
- `UnauthorizedAccessException` sobre `obj/Debug/net10.0/apphost.exe`

## Capas afectadas
- **Web / Presentation**
  - `minipokedex/minipokedex.csproj`

## Decisión técnica
Se configura:

```xml
<UseAppHost>false</UseAppHost>
```

Con esto, el proceso de build no intenta generar/reescribir `apphost.exe`, eliminando el punto de fallo por bloqueo/permisos del archivo en algunos entornos Windows.

## Impacto arquitectónico
- **Clean Architecture / DDD / SOLID**: sin impacto en diseño de dominio ni flujos de aplicación; es un ajuste de empaquetado/compilación en capa Web.
- No cambia comportamiento funcional de casos de uso ni acceso a datos.

## Validación de fuente de datos
- Sin cambios: se mantiene **PokeAPI** como única fuente de datos.

## Versión asociada
- `0.1.3`
