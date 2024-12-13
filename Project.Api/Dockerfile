# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["Project.Api/Project.Api.csproj", "Project.Api/"]
COPY ["Finance/Project.Finance.Controllers/Project.Finance.Controllers.csproj", "Finance/Project.Finance.Controllers/"]
COPY ["Finance/Project.Finance.Application/Project.Finance.Application.csproj", "Finance/Project.Finance.Application/"]
COPY ["Finance/Project.Finance.Domain/Project.Finance.Domain.csproj", "Finance/Project.Finance.Domain/"]
COPY ["Finance/Project.Finance.Infrastructure/Project.Finance.Infrastructure.csproj", "Finance/Project.Finance.Infrastructure/"]

# Restore dependencies
RUN dotnet restore "./Project.Api/Project.Api.csproj"

# Copy the rest of the source code
COPY . .

# Set the working directory to the API project and build it
WORKDIR "/src/Project.Api"
RUN dotnet build "./Project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: use the runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy the published output from the previous stage
COPY --from=publish /app/publish .

# Set the entrypoint to the API
ENTRYPOINT ["dotnet", "Project.Api.dll"]
