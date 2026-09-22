# API REST - Arquitectura N-Layers

Procedimiento para desarrollar una arquitectura basada en capas, que explica la responsabilidad de cada capa, de quién depende y cómo fluye la información en relación a una petición HTTP hasta la base de datos.

## Integrantes
- Carranza Leandro
- Carrizo Franco
- Saavedra Mauricio

## Stack
- C# / .NET
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / PostgreSQL
- Swagger

## Arquitectura

El proyecto está organizado en capas:

- **Presentation**: recibe las solicitudes HTTP, invoca la lógica de negocio y arma la respuesta.
- **BusinessLogic**: aplica validaciones y ejecuta la lógica de negocio.
- **DataAccess**: genera las consultas hacia la base de datos.
- **Entities**: entidades y elementos compartidos (utils, helpers, enums).

Proyectos de soporte:
- **Backend** (`NLayers.Api`): punto de entrada de la aplicación.
- **Core**: librerías con funcionalidades transversales.

## Estructura del proyecto

\`\`\`
NLayers.sln
├── backend/
│   └── NLayers.Api/
├── core/
└── layers/
    ├── NLayers.Presentation/
    ├── NLayers.BusinessLogic/
    ├── NLayers.DataAccess/
    └── NLayers.Entities/
\`\`\`


# Avance individual — Mauricio

## Rama de trabajo

`feature/category-mauricio`

Todo el desarrollo se realizó sobre una rama propia, sin trabajar directamente sobre `main`.

## Funcionalidad implementada: Category

### Entities

Se creó:

`NLayers.Entities/Models/Category.cs`

Propiedades principales:

- `Id`
- `Name`
- `Description`

### DataAccess

Se creó:

`NLayers.DataAccess/Stores/CategoryStore.cs`

Métodos implementados:

- `GetAll()`
- `GetById(int id)`
- `Add(Category category)`

Actualmente el almacenamiento se realiza en memoria.

### BusinessLogic

Se creó:

`NLayers.BusinessLogic/Managers/CategoryManager.cs`

Responsabilidades:

- Obtener categorías.
- Buscar una categoría por ID.
- Crear categorías.
- Validar que el nombre no esté vacío.

### Presentation

Se crearon:

- `CreateCategoryInput.cs`
- `CategoryOutput.cs`
- `CategoryController.cs`

Endpoints implementados:

- `GET /api/categories`
- `GET /api/categories/{id}`
- `POST /api/categories`

## Configuración adicional

En `NLayers.Presentation.csproj` se agregó:

```xml
<FrameworkReference Include="Microsoft.AspNetCore.App" />

Estado actual
Entities ✅
DataAccess ✅
BusinessLogic ✅
Presentation ✅
Compilación correcta ✅
