FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["*.csproj", "alfred-api/"]
RUN dotnet restore "alfred-api/alfred-api.csproj"
COPY . "alfred-api/"
WORKDIR "/src/alfred-api"
RUN dotnet build "alfred-api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "alfred-api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "alfred-api.dll"]
