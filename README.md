# mbs-minipokedex-codex

MiniPokedex desarrollada en ASP.NET Core MVC sobre .NET 10, con arquitectura en capas (Domain, Application, Infrastructure, Web) e integración con PokeAPI.

## Requisitos

- SDK de .NET 10

## Ejecución

```bash
dotnet restore
dotnet run --project minipokedex/minipokedex.csproj
```

## Fuente de datos

- API: `https://pokeapi.co/api/v2/`
- Contrato base: `context/pokeapi-openapi.json`

## Versión

- `0.1.1`
