# Imagen base para .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de la solución y restaura dependencias
COPY ["ElCaminante.Api/ElCaminante.Api.csproj", "ElCaminante.Api/"]
COPY ["ElCaminante.Application/ElCaminante.Application.csproj", "ElCaminante.Application/"]
COPY ["ElCaminante.Infrastructure/ElCaminante.Infrastructure.csproj", "ElCaminante.Infrastructure/"]
COPY ["ElCaminante.Domain/ElCaminante.Domain.csproj", "ElCaminante.Domain/"]
RUN dotnet restore "ElCaminante.Api/ElCaminante.Api.csproj"

# Copia el resto del código y publica
COPY . .
WORKDIR "/src/ElCaminante.Api"
RUN dotnet publish "ElCaminante.Api.csproj" -c Release -o /app/publish

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "ElCaminante.Api.dll"]