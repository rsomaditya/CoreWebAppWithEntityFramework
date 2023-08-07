# CoreWebAppWithEF
Its a Dotnet Core(6) WEB API project using Entity Framework(7) and MS SQL Server(2019). This project is diveided in to two parts:
A. Implementing Entity Framework
B. Implementing Web API.

A) First, Entity Framework Implementation

1. create new project, template: ASP.NET Core Web App MVC
2. Install following packages from nuget package manager:
     a) Microsoft.EntityFramework.Core (7.0.9)
     b) Microsoft.EntityFramework.Core.SqlServer (7.0.9)
     c) Microsoft.EntityFramework.Core.Tools (7.0.9)
4. Add a new class 'Candidate.cs' under 'Models' folder.
5. Create a Folder 'Context' in folder to define Db Context and Add a new class 'LmsContext.cs'
6. Define connection string in 'appsettings.json':
    To find it easily first goto 'View->Server Explorer->Connect to Database'.
    Once the DB is connected, right click on the DB and goto 'Properties' and copy the connection string.
    Add 'Trusted_Connection=True;TrustServerCertificate=True;' to the string for Windows Authentication mode.

7.  Add the following DbContext in ConfigureServices of 'Program.cs'
    builder.Services.AddDbContext<LmsContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DbLMS")));
8. Once everything is completed rebuild the solution.
9. Now Open the Package manager console and run 'add-migration MigrationV1' to create a migration of LmsContext. Once MigrationV1 is executed properly a new folder 'Migrations' is generated with subsequent files.
10. Run 'update-database' in the Package Manager console to execute generated migration files in order to update the physical Database.
11. Oncec its done, check in SSMS that the new DB along with the table has been created.


