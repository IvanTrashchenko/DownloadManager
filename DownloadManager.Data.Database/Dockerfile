# Use a SQL Server image from Microsoft
FROM mcr.microsoft.com/mssql/server:2022-latest

# Set environment variables for SQL Server
ENV SA_PASSWORD=Passw0rd
ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Developer

# Switch to the root user to perform privileged operations
USER root

# Create a directory with appropriate permissions (use /var/opt/mssql)
RUN mkdir -p /var/opt/mssql/sqlscripts

# Copy all your SQL files from the host to the container
COPY ./Table /var/opt/mssql/sqlscripts

# Copy entrypoint script to the container
COPY ./entrypoint.sh /var/opt/mssql/entrypoint.sh

# Make the entrypoint script executable
RUN chmod +x /var/opt/mssql/entrypoint.sh

# Switch back to the mssql user to run SQL Server
USER mssql

# Expose the default SQL Server port
EXPOSE 1433

# Start SQL Server and run the entrypoint script
CMD /bin/bash /var/opt/mssql/entrypoint.sh
