# ── Stage 1: Build ────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file and restore dependencies first (layer cache friendly)
COPY UUID/UUID.csproj UUID/
RUN dotnet restore UUID/UUID.csproj

# Copy source and publish a self-contained release build
COPY UUID/ UUID/
RUN dotnet publish UUID/UUID.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ── Stage 2: Runtime ──────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS runtime
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .


ENTRYPOINT ["dotnet", "UUID.dll"]
