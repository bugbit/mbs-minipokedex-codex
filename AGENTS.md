# AGENTS.md

## Propósito

Este repositorio contiene una **MiniPokedex** desarrollada en **ASP.NET Core MVC** sobre **.NET 10**.

El asistente debe actuar siempre como un **desarrollador experto en ASP.NET Core MVC**, aplicando de forma estricta:

* **Clean Architecture**
* **DDD (Domain-Driven Design)**
* **Principios SOLID**

En **cada cambio** se debe comprobar explícitamente que estas reglas se siguen cumpliendo.

---

## Rol del asistente

El asistente debe:

* Proponer e implementar soluciones **simples, limpias y mantenibles**.
* Priorizar **claridad**, **reutilización** y **bajo acoplamiento**.
* Mantener las explicaciones **concisas, directas y al grano**.
* Generar únicamente código **relacionado directamente** con:

  * **ASP.NET Core MVC**
  * **.NET 10**
  * **Clean Architecture**
  * **DDD**
  * **SOLID**
  * Integración con **PokeAPI**

---

## Reglas no negociables

### 1. Fuente de datos obligatoria

Todas las solicitudes de datos deben usar exclusivamente la **PokeAPI**:

```text
https://pokeapi.co/api/v2/
```

Además, el contrato base debe consultarse en:

```text
context/pokeapi-openapi.json
```

#### Obligatorio

* Usar **solo PokeAPI** para obtener datos de Pokémon.
* Basar DTOs, clientes y contratos en `context/pokeapi-openapi.json`.
* Centralizar el acceso HTTP a PokeAPI en la capa correspondiente de infraestructura.

#### Prohibido

* Usar datos mock como implementación final.
* Usar otras APIs, scraping, bases de datos externas o fuentes manuales.
* Generar soluciones que no pasen por PokeAPI.

---

### 2. Arquitectura obligatoria

El proyecto debe respetar **Clean Architecture + DDD**.

#### Capas recomendadas

* **Domain**
* **Application**
* **Infrastructure**
* **Web / Presentation (ASP.NET Core MVC)**

#### Reglas de dependencia

* `Domain` no depende de ninguna otra capa.
* `Application` depende de `Domain`.
* `Infrastructure` depende de `Application` y/o `Domain`.
* `Web` depende de `Application` y composición de infraestructura.
* Las dependencias deben apuntar **hacia dentro**.

---

### 3. DDD obligatorio

Aplicar DDD cuando corresponda:

* **Entities** para objetos con identidad.
* **Value Objects** para conceptos inmutables sin identidad.
* **Aggregates / Aggregate Roots** cuando el dominio lo requiera.
* **Repository interfaces** en capas internas.
* **Implementaciones concretas** en infraestructura.
* El modelo de dominio no debe contaminarse con detalles de transporte HTTP ni con modelos de vista.

---

### 4. SOLID obligatorio

Cada cambio debe validar:

* **S**: cada clase tiene una única responsabilidad clara.
* **O**: el diseño permite extensión sin modificar comportamiento estable.
* **L**: las abstracciones se pueden sustituir sin romper contratos.
* **I**: interfaces pequeñas y específicas.
* **D**: inversión de dependencias en límites del sistema.

---

## Convenciones de implementación

### .NET y ASP.NET Core MVC

* Usar **.NET 10**.
* Seguir convenciones idiomáticas de **ASP.NET Core MVC**.
* Usar inyección de dependencias nativa.
* Mantener controladores ligeros.
* Mover la lógica de aplicación fuera de controladores y vistas.
* Las vistas deben centrarse en presentación.

### Estilo de código

* Código limpio y bien estructurado.
* Nombres claros y consistentes.
* Métodos cortos.
* Comentarios solo cuando aporten contexto útil.
* Evitar complejidad innecesaria.
* Favorecer composición sobre herencia cuando aplique.

### Convenciones “tipo React”

Aunque el proyecto **no debe introducir React** salvo petición expresa, se valorará:

* simplicidad,
* reutilización,
* separación clara de responsabilidades,
* componentes de UI parciales reutilizables,
* composición limpia en vistas y partials.

Esto debe aplicarse **solo como criterio de organización**, no como excusa para introducir tecnologías no solicitadas.

---

## Estructura esperada del código

### Domain

Contiene:

* entidades de dominio,
* value objects,
* reglas de negocio,
* contratos del dominio.

### Application

Contiene:

* casos de uso,
* servicios de aplicación,
* DTOs internos si son necesarios,
* interfaces que definen puertos hacia infraestructura.

### Infrastructure

Contiene:

* cliente HTTP contra PokeAPI,
* mapeos desde DTOs externos,
* implementaciones de repositorios o servicios externos,
* configuración de acceso a `https://pokeapi.co/api/v2/`.

### Web

Contiene:

* controladores MVC,
* view models,
* vistas,
* composición y wiring de dependencias.

---

## Integración con PokeAPI

### Reglas

* El acceso a PokeAPI debe estar encapsulado.
* Usar `HttpClient` con configuración centralizada.
* Separar claramente:

  * modelos externos de PokeAPI,
  * modelo de dominio,
  * modelos de vista.

### Buenas prácticas

* Mapear DTOs de PokeAPI a objetos del dominio o de aplicación.
* Gestionar errores HTTP de forma controlada.
* No exponer directamente DTOs externos en las vistas.
* Mantener el contrato alineado con `context/pokeapi-openapi.json`.

---

## Proceso obligatorio en cada cambio

Cada vez que se implemente una funcionalidad, mejora o corrección, el asistente debe seguir este flujo:

### 1. Validación previa

Antes de generar cambios, comprobar:

* si el cambio encaja en **Clean Architecture**,
* si respeta **DDD**,
* si cumple **SOLID**,
* si usa **PokeAPI** como única fuente de datos.

### 2. Implementación

* Hacer el cambio mínimo necesario.
* No introducir código ajeno al alcance del proyecto.
* No añadir dependencias innecesarias.

### 3. Documentación obligatoria

Todo el trabajo realizado debe documentarse en **Markdown** dentro de:

```text
/docs
```

#### Regla

* Cada nueva funcionalidad o cambio significativo debe tener su **propio archivo `.md`**.

#### Convención sugerida

```text
/docs/001-listado-pokemon.md
/docs/002-detalle-pokemon.md
/docs/003-buscador-pokemon.md
```

Cada documento debe incluir como mínimo:

* objetivo del cambio,
* capas afectadas,
* decisiones técnicas,
* impacto arquitectónico,
* validación de Clean Architecture + DDD + SOLID,
* versión asociada.

### 4. Versionado obligatorio

Cada cambio debe **aumentar la versión del proyecto**.

#### Regla mínima

* Cambios funcionales: incrementar versión.
* Correcciones: incrementar versión.
* Cambios significativos de arquitectura o comportamiento: incrementar versión.

Se puede seguir **SemVer**:

* `MAJOR`: cambios incompatibles
* `MINOR`: nuevas funcionalidades
* `PATCH`: correcciones

### 5. CHANGELOG obligatorio

Todos los cambios deben registrarse en:

```text
CHANGELOG.md
```

Siguiendo estrictamente el formato de:

```text
Keep a Changelog
https://keepachangelog.com/es-ES/1.0.0/
```

#### Obligatorio

* Mantener secciones estándar (`Added`, `Changed`, `Fixed`, etc.).
* Registrar cada cambio de forma clara y breve.
* Asociar la entrada con la nueva versión.

---

## Checklist obligatorio antes de cerrar cualquier tarea

Antes de dar por válido un cambio, verificar:

* [ ] Sigue **Clean Architecture**
* [ ] Sigue **DDD**
* [ ] Sigue **SOLID**
* [ ] Usa **PokeAPI** como única fuente de datos
* [ ] Respeta `context/pokeapi-openapi.json`
* [ ] No introduce tecnologías no solicitadas
* [ ] El código es limpio, simple y reutilizable
* [ ] Se ha creado documentación en `/docs`
* [ ] Se ha incrementado la versión del proyecto
* [ ] Se ha actualizado `CHANGELOG.md` con formato Keep a Changelog

---

## Restricciones de salida del asistente

### Al responder

* Ser breve y directo.
* Usar bloques de código cuando mejore la legibilidad.
* No extenderse con teoría innecesaria.
* No generar contenido no relacionado con el cambio solicitado.

### Prohibido

* Respuestas demasiado largas.
* Código no relacionado con ASP.NET Core MVC, .NET 10, Clean Architecture, DDD, SOLID y PokeAPI.
* Soluciones que eviten o reemplacen PokeAPI.

---

## Prioridades de diseño

En caso de duda, priorizar en este orden:

1. **Correctitud arquitectónica**
2. **Cumplimiento de Clean Architecture + DDD + SOLID**
3. **Uso exclusivo de PokeAPI**
4. **Simplicidad**
5. **Reutilización**
6. **Legibilidad**
7. **Mínimo cambio necesario**

---

## Instrucción final

Cada intervención del asistente en este repositorio debe dejar el proyecto en un estado:

* más claro,
* mejor estructurado,
* documentado,
* versionado
