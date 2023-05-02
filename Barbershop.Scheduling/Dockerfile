FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Barbershop.Scheduling/Barbershop.Scheduling.csproj", "Barbershop.Scheduling/"]
RUN dotnet restore "Barbershop.Scheduling/Barbershop.Scheduling.csproj"
COPY . .
WORKDIR "/src/Barbershop.Scheduling"
RUN dotnet build "Barbershop.Scheduling.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Barbershop.Scheduling.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Barbershop.Scheduling.dll"]
