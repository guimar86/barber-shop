FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BarberShop.Management/BarberShop.Management.csproj", "BarberShop.Management/"]
RUN dotnet restore "BarberShop.Management/BarberShop.Management.csproj"
COPY . .
WORKDIR "/src/BarberShop.Management"
RUN dotnet build "BarberShop.Management.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BarberShop.Management.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BarberShop.Management.dll"]
