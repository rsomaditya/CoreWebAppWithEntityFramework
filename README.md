# CoreWebAppWithEF
Its a Dotnet Core(6) WEB API project using Entity Framework(7) and MS SQL Server(2019). This project is diveided in to three parts:\
<b>A. Implementing Entity Framework\
B. Implementing Web API\
C. Test API using POSTMAN</b>

<b>A) First, Entity Framework Implementation:</b>

1. create new project, template: ASP.NET Core Web App MVC
2. Install following packages from nuget package manager:\
     a) Microsoft.EntityFramework.Core (7.0.9)\
     b) Microsoft.EntityFramework.Core.SqlServer (7.0.9)\
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

<b>B) Web API Implementation:</b>

1. Add a new API controller class 'CandidateController.cs' in 'Controllers' folder and choose the read/write option to get all the http CRUD methods easily.
2. Implement the controller for each actions using DB Context class's ('LmsContext.cs') object. Here for all WRITE operation with DB, SaveChanges() shall is been called.
3. Add "launchUrl": "Candidate" in 'launchsettings.json' under 'profiles.CoreWebAppWithEF' and 'profiles.IIS Express' both.
4. Once the CandidateController is been implemented rebuild the project and run it.
