# 🧩 Million Building

Aplicación web desarrollada con .NET Core 9 que permite gestionar propiedades inmobiliarias en Estados Unidos. Proporciona una API REST para realizar operaciones CRUD sobre entidades del dominio y está diseñada bajo una arquitectura por capas.

---

## 🚀 Tecnologías utilizadas

- .NET Core 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Scalar
- NUnit

---

## 📁 Estructura del proyecto

```text
Million.Building/
├── LayerApplication/       # Lógica de negocio
│   └── BusinessRules/
├── LayerCommon/            # Funcionalidades reutilizables
│   └── Utilities/
├── LayerDomain/            # Modelos del dominio
│   └── Entities/
├── LayerInfrastructure/    # Comunicación con componentes externos
│   ├── DataAccess/
│   └── Storage/
├── LayerPresentation/      # Capa de exposición (API)
│   └── BuildingApi/
├── Test/                   # Pruebas unitarias
│   └── UnitTest/
```

---

## 🔧 Requisitos previos

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Docker](https://www.docker.com/)

---

## ⚙️ Instalación y configuración

1. Clona el repositorio:

```bash
git clone https://github.com/c-go-m/MillionBuilding.git
cd MillionBuilding
```

2. Restaura los paquetes NuGet:

```bash
dotnet restore
```

3. Configura las variables de entorno en `MillionBuilding/BuildingApi/Properties/launchSettings.json`:

```json
{
  "profiles": {
    "http": {
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "CONFIGURATION_APPLICATION_CORS_POLICY": "http://localhost:4200",
        "CORS_POLICY": "cors_policy",
        "CONNECTION_STRING_DATABASE": "Server=localhost,9005;Database=million_building;User Id=sa;Password=Mayo_2025.,*;TrustServerCertificate=True;",
        "JWT_ISSUER": "https://api.million.com",
        "JWT_AUDIENCE": "https://api.million.com",
        "JWT_KEY": "HuN3v!2KD8s93l*Pq2Ws9ZmQ5cXyRz8B",
        "JWT_EXPIRE": "30"
      }
    }
  }
}
```

---

## 🐳 Ejecución con Docker Compose

Levanta todos los servicios definidos en el archivo `docker-compose.yml`:

```bash
docker-compose up -d --build --force-recreate
```

---

## ▶️ Ejecución manual del proyecto

Para iniciar la API localmente:

```bash
dotnet run --project ./LayerPresentation/BuildingApi
```

La API estará disponible en:

- 🌐 http://localhost:9001
- 📘 Swagger / Scalar: http://localhost:9001/scalar

---

## ✅ Pruebas unitarias

Ejecuta las pruebas con:

```bash
dotnet test
```

---

## 🔐 Autenticación y consumo de API

### 1. Obtener token de autenticación

```bash
curl http://localhost:9001/User/Login   --request POST   --header 'Content-Type: application/json'   --data '{
    "userName": "admin",
    "password": "admin"
  }'
```

### 2. Consumir endpoints protegidos

```bash
curl http://localhost:9001/User   --header 'Authorization: Bearer <token>'
```

---

## 🔎 Filtros y paginación en la API

Formato estándar para solicitudes con filtros:

```json
{
  "filters": [
    {
      "name": "campo",       // Nombre del campo a filtrar
      "value": "valor",      // Valor del filtro
      "operator": 1          // Operador: 0=Equals, 1=NotEquals, 2=Minor, 3=MinorEquals, 4=Mayor, 5=MayorEquals, 6=Contains
    }
  ],
  "sort": {
    "name": "campo",         // Campo de ordenamiento
    "direction": "Ascending" // o "Descending"
  },
  "page": {
    "page": 1,
    "pageSize": 10
  }
}
```

---

## 📬 Contacto

Desarrollado por [c-go-m](https://github.com/c-go-m)  
Contribuciones y mejoras son bienvenidas.

---