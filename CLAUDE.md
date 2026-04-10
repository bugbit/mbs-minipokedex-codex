# CLAUDE.md

## Convenciones de C# 12

### Constructores primarios para inyección de dependencias
- Usar constructores primarios para inyección de dependencias.
- Los parámetros del constructor **nunca** se usan directamente en métodos.
- Cada dependencia inyectada debe asignarse a un campo `readonly` con prefijo `_`.
- El cuerpo de la clase debe usar exclusivamente esos campos privados.
