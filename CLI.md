# Start Application
dotnet watch run
dotnet watch run --verbose

# Remove Migration
dotnet ef migrations remove
dotnet ef migrations remove --verbose

# Add Migration
dotnet ef migrations add <MIGRATION_NAME>
dotnet ef migrations add <MIGRATION_NAME> --verbose

# Update Database (After entities/models changes)
dotnet ef database update

# Create sqlite database
sqlite3 Mini_Theatre.db
.databases