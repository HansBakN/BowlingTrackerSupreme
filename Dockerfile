FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy source
COPY ./src ./

# Restore
RUN dotnet restore

# Build and publish
RUN dotnet publish --configuration Release -o publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080/tcp
ENTRYPOINT ["dotnet", "BowlingTrackerSupreme.Blazor.dll"]

