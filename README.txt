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


##Test project##

Unit testing  => Integration testing => System testing 

##Unit Test frameworks ##
MSTest => NUnit => XUnit

Advantages Of Xunit : The Modern and extensible choise / Extensibilility / Isolation of Tests / Parallel test execution ...

The AAA Pattern : Arrange - Act - Assert

*Arrange: Initialize Objects , Define Fields and set the Values To Data
         Exemple : int x = 5
                   int y = 2
*Act : Call the method being tested
            var z = x+y
*Assert: Make sure and verified the Methode is Work As Expected
          Assert.Equal(7,z)

