FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Booking.API/Booking.API.csproj", "Booking.API/"]
RUN dotnet restore "Booking.API/Booking.API.csproj"
COPY . .
WORKDIR "/src/Booking.API"
RUN dotnet build "Booking.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Booking.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Booking.API.dll"]
