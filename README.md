
# 🧩 Million Building 

Aplicación desarrollada con .NET Core 9 que permite gestionar las propiedades inmobiliarias en Estados Unidos.

## 🚀 Tecnologías utilizadas

- .NET Core 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server 
- Scalar 
- NUnit

## 📂 Estructura del proyecto

```
Million.Building/
├── LayerApplication/ "Capa encargada de manejar la logica de negocio"
│ └── BusinessRules/ 
├── LayerCommon/ "Capa que contiene las funcionalidades que podran ser reutilizables en toda la aplicacion"
│ └── Utilities/ 
├── LayerDomain/ "Capa que contiene las clases que modelan el negocio"
│ └── Entities/ 
├── LayerInfrastructure/ "Capa que contiene la clases que permiten la comunicacion con componente externos"
│ ├── DataAccess/
│ └── Storage/
├── LayerPresentation/ "Capa de permite exponer la funcionalidad de la aplicacion"
│ └── BuildingApi/
├── Test/
│ └── UnitTest/
```

## 🔧 Requisitos previos

- .NET 9 SDK
- SQL Server
- Visual Studio 2022
- Docker

## 🛠️ Instalación y configuración

1. Clonar el repositorio:

```bash
git clone https://github.com/c-go-m/MillionBuilding.git
cd MillionBuilding
```

2. Restaurar los paquetes NuGet:

```bash
dotnet restore
```

3. Configurar las variables de entorno de configuracion `\MillionBuilding\BuildingApi\PropertieslaunchSettings.json`

```json
{
  "profiles": {
    "http": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "scalar",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",        
        "CONFIGURATION_APPLICATION_CORS_POLICY": "http://localhost:4200",
        "CORS_POLICY": "cors_policy",
        "CONNECTION_STRING_DATABASE": "Server=localhost,9005;Database=million_building;User Id=sa;Password=Mayo_2025.,*;TrustServerCertificate=True;",
        "JWT_ISSUER": "https://api.million.com",
        "JWT_AUDIENCE": "https://api.million.com",
        "JWT_KEY": "HuN3v!2KD8s93l*Pq2Ws9ZmQ5cXyRz8B",
        "JWT_EXPIRE": "30"
      },
      "dotnetRunMessages": true,
      "applicationUrl": "http://localhost:5162"
    },
    "https": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "scalar",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "CONFIGURATION_APPLICATION_CORS_POLICY": "http://localhost:4200",
        "CORS_POLICY": "cors_policy",
        "CONNECTION_STRING_DATABASE": "Server=localhost,9005;Database=million_building;User Id=sa;Password=Mayo_2025.,*;TrustServerCertificate=True;",
        "JWT_ISSUER": "https://api.million.com",
        "JWT_AUDIENCE": "https://api.million.com",
        "JWT_KEY": "HuN3v!2KD8s93l*Pq2Ws9ZmQ5cXyRz8B",
        "JWT_EXPIRE": "30"
      },    
      "dotnetRunMessages": true,
      "applicationUrl": "https://localhost:7099;http://localhost:5162"
    },
    "Container (Dockerfile)": {
      "commandName": "Docker",
      "launchUrl": "{Scheme}://{ServiceHost}:{ServicePort}",
      "environmentVariables": {
        "ASPNETCORE_HTTPS_PORTS": "8081",
        "ASPNETCORE_HTTP_PORTS": "8080",
        "ASPNETCORE_ENVIRONMENT": "Development",
        "CONFIGURATION_APPLICATION_CORS_POLICY": "http://localhost:4200",
        "CORS_POLICY": "cors_policy",
        "CONNECTION_STRING_DATABASE": "Server=localhost,9005;Database=million_building;User Id=sa;Password=Mayo_2025.,*;TrustServerCertificate=True;",
        "JWT_ISSUER": "https://api.million.com",
        "JWT_AUDIENCE": "https://api.million.com",
        "JWT_KEY": "HuN3v!2KD8s93l*Pq2Ws9ZmQ5cXyRz8B",
        "JWT_EXPIRE": "30"
      },
      "publishAllPorts": true,
      "useSSL": true
    }
  },
  "$schema": "https://json.schemastore.org/launchsettings.json"
}
```

## ▶️ Ejecución del proyecto con docker compose

Ejecuta la aplicación con:

```bash
docker-compose up -d --build --force-recreate
```

## ▶️ Ejecución del proyecto

Ejecuta la aplicación con:

```bash
dotnet run
```

La API estará disponible en:  
🌐 `https://localhost:9001`  
📘 scalar: `https://localhost:9001/scalar`

## ✅ Ejecución de pruebas

```bash
dotnet test
```

