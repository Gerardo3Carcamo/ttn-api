# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 👉 Copiamos SOLO el csproj (está en la misma carpeta que este Dockerfile)
COPY ["ttn-hub.csproj", "ttn-hub/"]
RUN dotnet restore "./ttn-hub.csproj"

# 👉 Copiamos todo el código
COPY . .

# Ya estamos en /src, donde está el csproj
RUN dotnet build "./ttn-hub.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ttn-hub.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ttn-hub.dll"]
