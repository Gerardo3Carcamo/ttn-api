FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 👇 Copiamos el .csproj desde la ruta correcta dentro del repo
COPY ["ttn-hub.api/ttn-hub.api.csproj", "ttn-hub.api/"]
RUN dotnet restore "ttn-hub.api/ttn-hub.api.csproj"

# 👇 Copiamos todo el código
COPY . .
WORKDIR "/src/ttn-hub.api"
RUN dotnet build "ttn-hub.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ttn-hub.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ttn-hub.api.dll"]
