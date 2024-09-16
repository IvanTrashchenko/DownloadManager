# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to start (e.g., 30 seconds)
sleep 30s

# Create the database using
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'Passw0rd' -Q "CREATE DATABASE [DownloadManagerDb];" -N -C

# Run table deployment scripts
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'Passw0rd' -d DownloadManagerDb -i /var/opt/mssql/sqlscripts/User.sql -N -C
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'Passw0rd' -d DownloadManagerDb -i /var/opt/mssql/sqlscripts/File.sql -N -C

# Keep the container running
wait
