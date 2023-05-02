FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Barbershop.Payment/Barbershop.Payment.csproj", "Barbershop.Payment/"]
RUN dotnet restore "Barbershop.Payment/Barbershop.Payment.csproj"
COPY . .
WORKDIR "/src/Barbershop.Payment"
RUN dotnet build "Barbershop.Payment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Barbershop.Payment.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Barbershop.Payment.dll"]
