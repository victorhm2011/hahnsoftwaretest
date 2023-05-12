# Set the base image to the official .NET 6 SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY . ./

# Build the application
RUN dotnet build --configuration Release --no-restore

# Publish the application
RUN dotnet publish --configuration Release --no-build --output /app/publish

# Set the base image to the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Expose the port on which the application will listen
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "HahnTest.dll"]