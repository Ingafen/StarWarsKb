FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["StarWarsKb.Back/StarWarsKb.Back.csproj", "StarWarsKb.Back/"]
RUN dotnet restore "StarWarsKb.Back/StarWarsKb.Back.csproj"
COPY . .
WORKDIR "/src/StarWarsKb.Back"
RUN dotnet build "StarWarsKb.Back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StarWarsKb.Back.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir -p ~/.postgresql
RUN apt-get update && apt-get install -y wget
RUN wget "https://storage.yandexcloud.net/cloud-certs/CA.pem" -O ~/.postgresql/root.crt
RUN chmod 0600 ~/.postgresql/root.crt
ENTRYPOINT ["dotnet", "StarWarsKb.Back.dll"]