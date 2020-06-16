FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ACME.WebApi/ACME.WebApi.csproj", "ACME.WebApi/"]
RUN dotnet restore "ACME.WebApi/ACME.WebApi.csproj"
COPY . .
WORKDIR "/src/ACME.WebApi"
RUN dotnet build "ACME.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ACME.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ACME.WebApi.dll"]