# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Project.Api/Project.Api.csproj", "Project.Api/"]
COPY ["Finance/Project.Finance.Controllers/Project.Finance.Controllers.csproj", "Finance/Project.Finance.Controllers/"]
COPY ["Finance/Project.Finance.Application/Project.Finance.Application.csproj", "Finance/Project.Finance.Application/"]
COPY ["Finance/Project.Finance.Domain/Project.Finance.Domain.csproj", "Finance/Project.Finance.Domain/"]
COPY ["Finance/Project.Finance.Infrastructure/Project.Finance.Infrastructure.csproj", "Finance/Project.Finance.Infrastructure/"]
RUN dotnet restore "./Project.Api/Project.Api.csproj"
COPY . .
WORKDIR "/src/Project.Api"
RUN dotnet build "./Project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.Api.dll"]