# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Kopiera bara .csproj filen
COPY *.csproj ./

# Restore dependencies
RUN dotnet restore

# Kopiera bara de filer vi behöver (INTE testfil.cs)
COPY Program.cs ./

# Publish
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "personnummer-kontroll.dll"]
