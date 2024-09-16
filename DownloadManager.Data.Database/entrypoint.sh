#!/bin/bash

# Wait for SQL Server to start
 # echo "Waiting for SQL Server to start..."
 # for i in {1..50}; do
 #   /opt/mssql-tools18/bin/sqlcmd -S 10.3.2.4 -U sa -P $SA_PASSWORD -Q "SELECT 1" > /dev/null 2>&1 -No
 #   if [ $? -eq 0 ]; then
 #       echo "SQL Server is up and running!"
 #       break
 #   else
 #       echo "SQL Server is not yet ready, waiting..."
 #       sleep 5
 #   fi
# done

# /opt/mssql-tools18/bin/sqlcmd -S 10.3.2.4 -U sa -P 'Passw0rd'
# /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'Passw0rd'
# /opt/mssql-tools18/bin/sqlcmd -S dm-db -U sa -P 'Passw0rd'

# Check if there are any .sql files in the directory
#if ls /var/opt/mssql/sqlscripts/*.sql 1> /dev/null 2>&1; then
#    echo "SQL files found, starting execution."
#
#    # Run the SQL scripts using the correct path
#    /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i "/var/opt/mssql/sqlscripts/User.sql"
#    /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i "/var/opt/mssql/sqlscripts/File.sql"
#
#else
#    echo "No SQL files found in /var/opt/mssql/sqlscripts. Skipping execution."
#fi

#!/bin/bash

#!/bin/bash

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to start (e.g., 30 seconds)
sleep 30s

# Create the database using the -Q flag to run the query directly, skipping encryption checks
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'Passw0rd' -Q "CREATE DATABASE [DownloadManagerDb];" -N -C

# Run your table deployment scripts with skipped SSL verification and no encryption
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'Passw0rd' -d DownloadManagerDb -i /var/opt/mssql/sqlscripts/User.sql -N -C
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'Passw0rd' -d DownloadManagerDb -i /var/opt/mssql/sqlscripts/File.sql -N -C

# Keep the container running
wait
