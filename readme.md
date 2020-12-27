# Try "blazor a-beginners-guide"

<https://www.telerik.com/campaigns/blazor/wp-beginners-guide-ebook>

## Project

### Create solution and project

``` dotnet
dotnet new blazorwasm -o　Try_Blazor --hosted
```

* Try_Blazro.sln
  * Client
    * Try_Blazor.Client.csproj
  * Server
    * Try_Blazor.Server.csproj
  * Shared
    * Try_Blazor.Shared.csproj

### Create razor class library

``` dotnet
dotnet new razorclasslib -n Try_Blazor.RazorClassLib -o RazorClassLib
```

Add solution file

``` dotnet
dotnet sln add RazorClassLib
```

Add reference to client project

``` dotnet
dotnet add Client/Try_Blazor.Client.csproj reference RazorClassLib/Try_Blazor.RazorClassLib.csproj
```

## Run

``` dotnet
dotnet run --project "server"
```

or

``` dotnet
dotnet watch run --project "server"
# changes are reflected and restart
```

## Debug

## Tools

### Library Manager

```dotnet
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

#### Install

Installed libraries see libman.json

``` dotnet
libman install <liblary>@<version> -d <outputpath> --files <file>
```

#### Restore

``` dotnet
libman restore
```

#### Uninstall

``` dotnet
libman uninstall <library>
```

### BuildWebCompiler

``` dotnet
dotnet add Client package BuildWebCompiler --version 1.12.405
```

Create Client\compilerconfig.json file and build setting here

## Consume class from Razor Class Library

1. dotnet - Create "Razor Class Library" project"
1. dotnet - Add reference to client project
1. client - DI
    1. client/Program.cs - Add services that consume class
    1. consume class dependencies were resolved by service
       explaned at [docs.microsoft](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0#overview-of-dependency-injection)
       "The implementation of the IMyDependency"
1. client/"Consumer".razor - Use @Inject delective
