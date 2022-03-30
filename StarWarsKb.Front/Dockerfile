FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["StarWarsKb.Front/StarWarsKb.Front.csproj", "StarWarsKb.Front/"]
RUN dotnet restore "StarWarsKb.Front/StarWarsKb.Front.csproj"
COPY . .
WORKDIR "/src/StarWarsKb.Front"
RUN dotnet build "StarWarsKb.Front.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StarWarsKb.Front.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StarWarsKb.Front.dll"]
