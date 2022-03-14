FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5094
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
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
