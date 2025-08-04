# dotnet-practice-crud
ASP.NET Core CRUD practice project

## Prerequisites
- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/) (optional, for development)
- [Postman](https://www.postman.com/downloads/) or similar API testing tool (optional, for testing)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (optional, for database operations)
- [Git](https://git-scm.com/downloads) (optional, for version control)

# Getting Started
1. Clone the repository:
   `git clone https://github.com/matisslaksevics/dotnet-practice-crud.git`
2. Navigate to the project directory:
   `cd dotnet-practice-crud`
3. Restore the dependencies:
   `dotnet restore`
4. Open the project in Visual Studio or your preferred IDE.
5. Run the migrations to set up the database:
   `dotnet ef database update` or use the Package Manager Console: `Update-Database`
6. Start the application with IIS Express or with the command:
   `dotnet run`

# Notes
- The project uses Entity Framework Core for database operations.
- The database connection string is configured in `appsettings.json` - make sure to update it with your SQL Server instance details.
- The project is set up to use .NET 8.0 and C# 12.0 features.
- For API testing, you can use Postman to send requests to the endpoints defined in the `Controllers` folder.

# About the project
This project is a practice CRUD application built with ASP.NET Core. It demonstrates how to create, read, update, and delete records in a database using Entity Framework Core. The application is structured to follow best practices in ASP.NET Core development, including dependency injection, repository pattern, and unit testing.

# License
This project is licensed under the MIT License.

# Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue if you find any bugs or have suggestions for improvements.
