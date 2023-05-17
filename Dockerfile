# Собираем приложение
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env

WORKDIR /server

COPY *.csproj ./

RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /publish

# Запускаем приложение
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

WORKDIR /publish

COPY --from=build-env /publish .

ENTRYPOINT ["dotnet", "api.dll"]