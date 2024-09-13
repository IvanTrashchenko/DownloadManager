# Stage 1: Build Angular Client
FROM mcr.microsoft.com/windows/servercore:ltsc2019 AS client-build

# Install Node.js
RUN powershell -Command \
    curl.exe -L -o nodejs.msi https://nodejs.org/dist/v18.17.0/node-v18.17.0-x64.msi; \
    Start-Process msiexec.exe -ArgumentList '/i', 'nodejs.msi', '/quiet', '/norestart' -NoNewWindow -Wait

# Set the working directory inside the container
WORKDIR /app

# Copy client app into the container
COPY DownloadManager.Web/ClientApp /app

# Install dependencies
RUN npm install

# Build the Angular app for production
RUN npm run build --prod

# Stage 2: Build .NET Web API
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS server-build

# Set the working directory inside the container
WORKDIR /app

# Copy the entire solution/project into the container
COPY . /app

# Restore NuGet packages
RUN nuget restore DownloadManager.sln

# Publish API using FolderProfile
RUN msbuild /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /p:Configuration=Release DownloadManager.Web/DownloadManager.Web.csproj


# Stage 3: Final stage for deployment
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS final

# Set the working directory for IIS in the container
WORKDIR /inetpub/wwwroot

# Copy the published Angular app from client-build
COPY --from=client-build /app/dist/client-app/. /inetpub/wwwroot

# Copy the published .NET app from server-build
COPY --from=server-build /app/DownloadManager.Web/ClientApp/dist/client-app/. /inetpub/wwwroot

# Expose port 80 for the web app
EXPOSE 80

# Set up the logs directory with permissions at runtime
RUN powershell -Command \
    "New-Item -Path 'C:/inetpub/wwwroot/logs' -ItemType Directory -Force; \
     icacls 'C:/inetpub/wwwroot/logs' /grant 'IIS_IUSRS:(OI)(CI)F' /T; \
     icacls 'C:/inetpub/wwwroot/logs' /grant 'NETWORK SERVICE:(OI)(CI)F' /T"

# Set IIS as the entrypoint
ENTRYPOINT ["C:\\ServiceMonitor.exe", "w3svc"]