# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto (csproj) e restaura as dependências
COPY ["src/SistemaUniversitario.Web/SistemaUniversitario.Web.csproj", "src/SistemaUniversitario.Web/"]
COPY ["src/SistemaUniversitario.Application/SistemaUniversitario.Application.csproj", "src/SistemaUniversitario.Application/"]
COPY ["src/SistemaUniversitario.Domain/SistemaUniversitario.Domain.csproj", "src/SistemaUniversitario.Domain/"]
COPY ["src/SistemaUniversitario.Infrastructure/SistemaUniversitario.Infrastructure.csproj", "src/SistemaUniversitario.Infrastructure/"]

RUN dotnet restore "src/SistemaUniversitario.Web/SistemaUniversitario.Web.csproj"

# Copia todo o resto do código e compila
COPY . .
WORKDIR "/src/src/SistemaUniversitario.Web"
RUN dotnet build "SistemaUniversitario.Web.csproj" -c Release -o /app/build

# Estágio de Publicação
FROM build AS publish
RUN dotnet publish "SistemaUniversitario.Web.csproj" -c Release -o /app/publish

# Estágio Final (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaUniversitario.Web.dll"]