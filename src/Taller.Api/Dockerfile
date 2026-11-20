# Se construye desde la raíz del repositorio: docker build -f src/Taller.Api/Dockerfile .
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Primero solo los .csproj, para aprovechar la caché de Docker en el restore.
COPY src/Taller.Domain/Taller.Domain.csproj src/Taller.Domain/
COPY src/Taller.Application/Taller.Application.csproj src/Taller.Application/
COPY src/Taller.Infrastructure/Taller.Infrastructure.csproj src/Taller.Infrastructure/
COPY src/Taller.Api/Taller.Api.csproj src/Taller.Api/
RUN dotnet restore src/Taller.Api/Taller.Api.csproj

COPY src/ src/
RUN dotnet publish src/Taller.Api/Taller.Api.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
# La imagen oficial escucha en el puerto 8080 y corre con un usuario sin privilegios.
EXPOSE 8080
ENTRYPOINT ["dotnet", "Taller.Api.dll"]
