FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Polygon.WebServices/Polygon.WebServices.csproj Polygon.WebServices/
COPY Polygon.Data/Polygon.Data.csproj Polygon.Data/
COPY Polygon.Domain/Polygon.Domain.csproj Polygon.Domain/
COPY Polygon.Services/Polygon.Services.csproj Polygon.Services/
RUN dotnet restore Polygon.WebServices/Polygon.WebServices.csproj
COPY . .
WORKDIR /src/Polygon.WebServices
RUN dotnet build Polygon.WebServices.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Polygon.WebServices.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Polygon.WebServices.dll"]
