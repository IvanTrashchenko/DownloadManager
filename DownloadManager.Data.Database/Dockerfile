# Use a Windows-based image with MSBuild tools to build the DACPAC
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019 AS sqlproj-build

# Set up environment variables
ENV sa_password="Passw0rd" 
ENV ACCEPT_EULA="Y"

# Install MSBuild and SQL Server Data Tools (SSDT) with necessary components
RUN powershell -Command \
    Invoke-WebRequest -Uri https://aka.ms/vs/17/release/vs_BuildTools.exe -OutFile vs_buildtools.exe -UseBasicParsing; \
    Start-Process -Wait -NoNewWindow -FilePath .\vs_buildtools.exe -ArgumentList '--quiet', '--wait', '--add', \
    'Microsoft.VisualStudio.Workload.DataBuildTools', '--add', 'Microsoft.Component.MSBuild', '--add', \
    'Microsoft.VisualStudio.Component.SQL.DataTools.MSBuild', '--includeRecommended'; \
    Remove-Item -Force .\vs_buildtools.exe

# Set the working directory inside the container
WORKDIR /src

# Copy the SQL project into the container
COPY . /src/

# Build the DACPAC from the SQL project using MSBuild
RUN msbuild DownloadManager.Data.Database.sqlproj /p:Configuration=Release /p:Platform="\"Any CPU\"" /t:Build

# Use a Windows Server Core image as the base
FROM mcr.microsoft.com/windows/servercore:ltsc2016 as final

# Set up environment variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Passw0rd
ENV DOCKER_ENV=true

# Create tools directory and download SqlPackage.exe
RUN powershell -Command \
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; \
    mkdir C:/app/sqlpackage; \
    Invoke-WebRequest -Uri "https://aka.ms/sqlpackage-windows" -OutFile "C:/app/sqlpackage/sqlpackage.zip"; \
    Expand-Archive -Path "C:/app/sqlpackage/sqlpackage.zip" -DestinationPath "C:/app/sqlpackage"; \
    Remove-Item "C:/app/sqlpackage/sqlpackage.zip"

# Copy the DACPAC file from the build stage
COPY --from=sqlproj-build /src/bin/Output/DownloadManager.Data.Database.dacpac /app/

# Expose SQL Server port
EXPOSE 1433

# Start SQL Server and publish the DACPAC to it
CMD ["cmd", "/C", "ping -n 30 127.0.0.1 > nul && C:/app/sqlpackage/SqlPackage.exe /Action:Publish /SourceFile:C:/app/DownloadManager.Data.Database.dacpac /TargetServerName:db /TargetDatabaseName:DownloadManagerDb /TargetUser:sa /TargetPassword:Passw0rd"]
