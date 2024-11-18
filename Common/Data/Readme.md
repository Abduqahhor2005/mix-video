dotnet ef migrations add InitialCreate --context BaseDbContext  --output-dir Common/Data/Migrations
dotnet ef database update --context BaseDbContext
dotnet restore
dotnet build
dotnet run