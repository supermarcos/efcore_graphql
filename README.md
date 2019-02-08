## Generating migrations

 - Open Visual Studio / this solution
 - Go to Tools > NuGet Package Manager > Package Manager Console
 - on the PM, write the command `Add-Migration unique_name_of_your_migration_here` and press enter
 - Wait for it to finish and you will have your new migration C# file in the folder Migrations

## Running migrations

 - Go again to the Package Manager Console
 - Write the command `update-database` and press enter
 - It will run all the not already run migration scripts and will change the database as defined
 
