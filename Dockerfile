FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
# Copia todo el contenido del repositorio
COPY . .
# Restaura dependencias
RUN dotnet restore
# Compila y publica
RUN dotnet publish -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .   
ENV ASPNETCORE_URLS=http://0.0.0.0:10000
EXPOSE 10000
ENTRYPOINT ["dotnet", "ApiRestau.dll"]