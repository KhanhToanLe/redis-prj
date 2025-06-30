# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files
COPY ["./MyCSharpProject/MyCSharpProject.csproj", "."]
RUN dotnet restore "MyCSharpProject.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "./MyCSharpProject/MyCSharpProject.csproj" -c Release -o /app/build
RUN dotnet publish "./MyCSharpProject/MyCSharpProject.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Install curl for health checks (optional)
RUN apt-get update && \
    apt-get install -y curl && \
    rm -rf /var/lib/apt/lists/*

# Copy from build stage
COPY --from=build /app/publish .

# Environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Expose port
EXPOSE 80

# Health check (optional)
HEALTHCHECK --interval=30s --timeout=3s --retries=3 \
    CMD curl -f http://localhost/health || exit 1

# Entry point
ENTRYPOINT ["dotnet", "MyCSharpProject.dll"]

# running docker 
# $ docker run -it -p 8155:80 -e ASPNETCORE_ENVIRONMENT=Development --name MyCSharp mycsharpproject