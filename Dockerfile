# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia os demais arquivos e faz o build
COPY . ./
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copia os arquivos compilados da etapa de build
COPY --from=build /out .

# Expondo a porta da aplicação
EXPOSE 5000
EXPOSE 5001

# Comando de inicialização do container
ENTRYPOINT ["dotnet", "LeadsService.dll"]
