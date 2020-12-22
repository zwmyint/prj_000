# prj_000 [my note]

// new solution file
dotnet new sln


//
// create new webapi application inside solution folder
dotnet new webapi -n prj_webapi

// add project to solution - webapi application
dotnet sln add prj_webapi/prj_webapi.csproj


//
// create new console application inside solution folder
dotnet new console -n prj_console

// add project to solution - console application
dotnet sln add prj_console/prj_console.csproj


// 
// create new console application inside solution folder
dotnet new classlib -n prj_classlib_DAL

// add project to solution - console application
dotnet sln add prj_classlib_DAL/prj_classlib_DAL.csproj


//
// add project reference to prj_webapi (inside project folder)
dotnet add prj_webapi.csproj reference ../prj_classlib_DAL/prj_classlib_DAL.csproj


//
dotnet run -p prj_console/prj_console.csproj


//------------------------------
// add react.js asp.net core project (there is ClientApp Folder included)
dotnet new react -o prj_aspnetcorereactjs

// add prj to sln
dotnet sln add prj_aspnetcorereactjs/prj_aspnetcorereactjs.csproj

//build sln

// go into the project folder and run (prj_aspnetcorereactjs.csproj)
dotnet watch run 

//------------------------------



//---------------

// controller without view and Generate a Controller with REST style API
/* dotnet aspnet-codegenerator controller -name Employee_X01Controller -m Employee_X01 -dc Employee_X01DbContext --relativeFolderPath Controllers --restWithNoViews --referenceScriptLibraries */




//--------------- //--------------- //--------------- //---------------
dotnet new sln

// ASP.Net Core Web API - the point of access for our application
dotnet new webapi -o MyMusic.Api

// Class Library - application’s foundation (contracts (interfaces, …), our models and everything else)
dotnet new classlib -o MyMusic.Core 

// Class Library - implement business logic
dotnet new classlib -o MyMusic.Services

// Class Library - Data access layer where we will connect with data providers (SQL Server)
dotnet new classlib -o MyMusic.Data


//Add the projects to the solution:
dotnet sln add MyMusic.Api/MyMusic.Api.csproj MyMusic.Core/MyMusic.Core.csproj MyMusic.Data/MyMusic.Data.csproj MyMusic.Services/MyMusic.Services.csproj


//link each depending project:
// api <<< core and services
dotnet add MyMusic.Api/MyMusic.Api.csproj reference MyMusic.Core/MyMusic.Core.csproj MyMusic.Services/MyMusic.Services.csproj

// data <<< core
dotnet add MyMusic.Data/MyMusic.Data.csproj reference MyMusic.Core/MyMusic.Core.csproj

// services <<< core
dotnet add MyMusic.Services/MyMusic.Services.csproj reference MyMusic.Core/MyMusic.Core.csproj

// api <<< services, core and data
dotnet add MyMusic.Api/MyMusic.Api.csproj reference MyMusic.Services/MyMusic.Services.csproj MyMusic.Core/MyMusic.Core.csproj MyMusic.Data/MyMusic.Data.csproj



// to install EF
dotnet tool install --global dotnet-ef


// add Dependencies to MyMusic.Data.csproj
dotnet add MyMusic.Data/MyMusic.Data.csproj package Microsoft.EntityFrameworkCore
dotnet add MyMusic.Data/MyMusic.Data.csproj package Microsoft.EntityFrameworkCore.Design
dotnet add MyMusic.Data/MyMusic.Data.csproj package Microsoft.EntityFrameworkCore.SqlServer

dotnet add MyMusic.Api/MyMusic.Api.csproj package Microsoft.EntityFrameworkCore.Design

// create migrations with the following command:
dotnet ef --startup-project MyMusic.Api/MyMusic.Api.csproj migrations add InitialModel -p MyMusic.Data/MyMusic.Data.csproj

// to reflect our migrations in our database with the following command:
dotnet ef --startup-project MyMusic.Api/MyMusic.Api.csproj database update

// Seed some data (add some dummy data to our database.)
// create an empty migration with
dotnet ef --startup-project MyMusic.Api/MyMusic.Api.csproj migrations add SeedMusicsAndArtistsTable -p MyMusic.Data/MyMusic.Data.csproj


// add Swagger "Swashbuckle.AspNetCore" Version="5.6.3"
dotnet add MyMusic.Api/MyMusic.Api.csproj package Swashbuckle.AspNetCore --version 5.0.0-rc3

// run MyMusic.api project
dotnet run -p MyMusic.Api/MyMusic.Api.csproj
// WILL GET ERROR HERE

// now for the mapping we are gonna use AutoMapper.
// For that we need to add to packages to our API project with:
dotnet add MyMusic.Api/MyMusic.Api.csproj package AutoMapper 
dotnet add MyMusic.Api/MyMusic.Api.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection

// run again MyMusic.api project
dotnet run -p MyMusic.Api/MyMusic.Api.csproj


// add FluentValidation package to our project
dotnet add MyMusic.Api/MyMusic.Api.csproj package FluentValidation
