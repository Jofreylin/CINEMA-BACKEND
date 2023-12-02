# Use the official image as a parent image.
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory.
WORKDIR /app

# Copy csproj and restore as distinct layers.
COPY *.sln .
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY Web_API/*.csproj ./Web_API/
RUN dotnet restore

# Copy everything else and build app.
COPY Application/. ./Application/
COPY Domain/. ./Domain/
COPY Infrastructure/. ./Infrastructure/
COPY Web_API/. ./Web_API/
RUN dotnet publish -c Release -o out

# Build runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Web_API.dll"]
