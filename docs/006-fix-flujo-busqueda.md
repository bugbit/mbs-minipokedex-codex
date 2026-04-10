# 006 - Fix flujo de búsqueda

## Objetivo del cambio
Corregir el flujo de búsqueda desde el listado para evitar respuestas 404 al usuario final y mostrar feedback claro cuando la búsqueda no tiene resultados o la entrada está vacía.

## Capas afectadas
- **Web (ASP.NET Core MVC)**
  - `PokemonController`: nueva acción `Search`.
  - `Views/Pokemon/Index.cshtml`: formulario actualizado y mensaje de error visual.

## Decisiones técnicas
- Se agrega una acción `Search` en el controlador para encapsular la lógica de validación de entrada y resolución de búsqueda.
- Se mantiene `Detail` como endpoint de detalle únicamente.
- Se usa `TempData` para transportar el mensaje de error al redirigir al listado.

## Impacto arquitectónico
- Se mantiene el controlador ligero y orientado a orquestación.
- La lógica de consulta sigue en `IPokemonQueryService` (Application), respetando dependencia hacia dentro.
- No se exponen DTOs externos de infraestructura en la vista.

## Validación Clean Architecture + DDD + SOLID
- **Clean Architecture**: solo se modifica la capa Web; Application/Domain/Infrastructure quedan desacopladas.
- **DDD**: no se introduce lógica de dominio en controladores o vistas.
- **SOLID**:
  - **S**: `Search` tiene responsabilidad única (validar/encaminar búsqueda).
  - **O**: flujo extensible para futuras reglas sin romper `Detail`.
  - **L/I/D**: se mantiene uso de la abstracción `IPokemonQueryService`.

## Fuente de datos
- Se conserva **PokeAPI** como única fuente de datos, a través de la infraestructura existente.

## Versión asociada
- `0.1.5`
