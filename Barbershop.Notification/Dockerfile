FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Barbershop.Notification/Barbershop.Notification.csproj", "Barbershop.Notification/"]
RUN dotnet restore "Barbershop.Notification/Barbershop.Notification.csproj"
COPY . .
WORKDIR "/src/Barbershop.Notification"
RUN dotnet build "Barbershop.Notification.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Barbershop.Notification.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Barbershop.Notification.dll"]
