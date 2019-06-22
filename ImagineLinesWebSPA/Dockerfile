FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base

#RUN apt-get update -y && apt-get install -y gnupg2 && curl -sL https://deb.nodesource.com/setup_10.x | bash - && apt-get update -y && apt-get install -y nodejs

WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ImagineLinesWebSPA/ImagineLinesWebSPA.csproj", "ImagineLinesWebSPA/"]
RUN dotnet restore "ImagineLinesWebSPA/ImagineLinesWebSPA.csproj"
COPY . .
WORKDIR "/src/ImagineLinesWebSPA"
RUN dotnet build "ImagineLinesWebSPA.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ImagineLinesWebSPA.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ImagineLinesWebSPA.dll"]
