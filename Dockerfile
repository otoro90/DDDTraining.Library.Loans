FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV TZ=America/Bogota
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DDDTraining.Library.Loans.Api/DDDTraining.Library.Loans.Api.csproj", "DDDTraining.Library.Loans.Api/"]
RUN dotnet restore "./DDDTraining.Library.Loans.Api/DDDTraining.Library.Loans.Api.csproj"
COPY . .
WORKDIR "/src/DDDTraining.Library.Loans.Api"
RUN dotnet build "./DDDTraining.Library.Loans.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DDDTraining.Library.Loans.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDDTraining.Library.Loans.Api.dll"]