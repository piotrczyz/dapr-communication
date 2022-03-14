FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0.101-bullseye-slim AS build
WORKDIR /src
COPY ["PaymentGatewayService.csproj", "./"]
RUN dotnet restore "PaymentGatewayService.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "PaymentGatewayService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentGatewayService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentGatewayService.dll"]
