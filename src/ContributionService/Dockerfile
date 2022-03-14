FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5127
ENV ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/sdk:6.0.101-bullseye-slim AS build
WORKDIR /src
COPY ["ContributionService.csproj", "./"]
RUN dotnet restore "ContributionService.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "ContributionService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContributionService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContributionService.dll"]
