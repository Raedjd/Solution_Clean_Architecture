##Buid CLEAN ARCHITECTURE PROJECT##
-Create ASP.NET Core Web API project with .NET8.0
-To list all the installed .NET SDK versions, you can use the following command:
dotnet --list-sdks
-To list all the installed .NET runtime versions, use the following command:
dotnet --list-runtimes
-If you want to check the .NET SDK version that is currently in use by default, simply run:
dotnet --version



//Connextion To SQL server
builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
