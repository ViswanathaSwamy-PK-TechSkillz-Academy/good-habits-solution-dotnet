# Good Habits Solution Dotnet

A Simple SaaS Solution .NET 7, C#, EF Core, SQL Azure, DI, Dto, Repository, Docker, Docker-Compose, and AKS. I am learning this from a book. I am using this as a reference for future projects.

## Projects

> 1. GoodHabits.Persistence

```bash
dotnet new classlib --name GoodHabits.Persistence;
```

> 1. GoodHabits.HabitsWeb

```bash
dotnet new blazorwasm -o GoodHabits.HabitsWeb
```

> 1. GoodHabits.UserService

```bash
dotnet new webapi -n GoodHabits.UserService
```

> 1. GoodHabits.ApiGateway

```bash
dotnet new webapi -n GoodHabits.ApiGateway;
```

> 1. GoodHabits.HabitsAPI

```bash
dotnet new webapi --name GoodHabits.HabitsAPI;

dotnet add reference ../GoodHabits.Persistence/GoodHabits.Persistence.csproj; \
dotnet add package Microsoft.EntityFrameworkCore.Design; \
cd ..;

dotnet run --project ./GoodHabits.HabitsAPI/GoodHabits.HabitsAPI.csproj

dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson;

root ➜ /workspace/GoodHabits.Persistence (swamy/01nov-good-habits-day1)>
dotnet-ef migrations add MultiTenant --startup-project ../GoodHabits.HabitsAPI/GoodHabits.HabitsAPI.csproj

dotnet-ef migrations add AdditionalEntities --startup-project ../GoodHabits.HabitsAPI/GoodHabits.HabitsAPI.csproj

dotnet-ef database update --startup-project ../GoodHabits.HabitsAPI/GoodHabits.HabitsAPI.csproj
```

> 1. GoodHabits.HabitsWeb

```bash
dotnet new blazorwasm -o GoodHabits.HabitsWeb;

dotnet run --project ./GoodHabits.HabitsWeb/GoodHabits.HabitsWeb.csproj
```

```bash
dotnet new sln --name GoodHabits; \
dotnet sln add ./GoodHabits.HabitsWeb/GoodHabits.HabitsWeb.csproj; \
dotnet sln add ./GoodHabits.HabitsAPI/GoodHabits.HabitsAPI.csproj; \
dotnet sln add ./GoodHabits.Persistence/GoodHabits.Persistence.csproj;
```

## Getting Started

```powershell
ms-vscode-remote.remote-containers
ms-vscode-remote.remote-wsl
ms-azuretools.vscode-docker

docker-compose up -d

docker exec -it dev-env /bin/bash
dotnet --version
dotnet-ef --version

docker exec -it sqlserver /bin/bash
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA
SELECT @@VERSION
GO

Remote-Containers: Rebuild and Reopen in Container

Remote-Containers: Reopen Folder Locally
```
