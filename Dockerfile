# Use the official Microsoft SDK image for ASP.NET Framework 4.8
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the entire solution/project into the container
COPY . /app

# Publish API using FolderProfile
RUN msbuild /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /p:Configuration=Release DownloadManager.Web/DownloadManager.Web.csproj

# Use the official Microsoft ASP.NET Framework 4.8 image for deployment
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8

# Set the working directory for IIS in the container
WORKDIR /inetpub/wwwroot

# Copy the published files from the build stage
COPY --from=build /app/DownloadManager.Web/ClientApp/dist/client-app/ .

# Expose port 80 for the web app
EXPOSE 80

# Set up the logs and bin directories with permissions at runtime
RUN powershell -Command \
    "New-Item -Path 'C:/inetpub/wwwroot/logs' -ItemType Directory -Force; \
     New-Item -Path 'C:/inetpub/wwwroot/bin' -ItemType Directory -Force; \
     icacls 'C:/inetpub/wwwroot/logs' /grant 'IIS_IUSRS:(OI)(CI)F' /T; \
     icacls 'C:/inetpub/wwwroot/bin' /grant 'IIS_IUSRS:(OI)(CI)F' /T; \
     icacls 'C:/inetpub/wwwroot/logs' /grant 'NETWORK SERVICE:(OI)(CI)F' /T; \
     icacls 'C:/inetpub/wwwroot/bin' /grant 'NETWORK SERVICE:(OI)(CI)F' /T"