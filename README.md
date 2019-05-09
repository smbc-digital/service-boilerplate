# Stockport WebAPI boilerplate.

This is the basis of a [custom .Net new template](https://docs.microsoft.com/en-gb/dotnet/core/tools/custom-templates) and can be used to generate restful WebApi project with default StockportGovUK setup and behaviours enabled.

## Installation from Nuget

To register this application template with the dotnet cli 

```
dotnet new --install StockportGovUK.AspNet.BoilerPlate.Service
```

### Creating/Updating the nuget package
To create a Nuget package for use as a template you need to use the Nuget CLI as opposed to the dotnet CLI. 

* [Install the CLI](https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools#nugetexe-cli).
* Navigate to folder cotaining the ```.nuspec``` file
* Call nuget pack

``` 
nuget pack
```

### Pushing a nuget package
You can use either the nuget CLI or the dotnet CLI to push the package. Below is the method for pushing the package using dotnet CLI.

```
dotnet nuget push StockportGovUK.AspNetCore.BoilerPlate.Service.#.#.#.nupkg -k <yourkeyhere> -s https://www.nuget.org
```

## Installation From Git/Folder

To register this application template with the dotnet cli 

* Clone this repository to a folder locally
* Navigate to the ```service-boilerplate/content``` folder
* install the the boilerplate using the --install switch

```
dotnet new --install .
```

* Check that the template has been regsitered using the --list switch, check for the presence of "smbc-webapi" record.

```
dotnet new --list

SMBC WebApi boilerplate    smbc-webapi    [C#]     WebApi
```

### Using the boilerplate

If you've followed the steps above you should be good to go and can use the newly installed template.

```
dotnet new smbc-webapi
```

All teh generated files are should match the name of your project, by default, this will be the name of the folder in which the project has been created. If you want to the project to have a specific name you can use the -n switch.

```
dotnet new smbc-webapi -n mytestproject
```

### Unistalling the boilerplate
Should you wish to uninstall template you can do this using the --uninstall switch.

Note that you must provide the correct fully realised path to the folder from which the template was originally installed.

```
dotnet new --uninstall \C\The\Fully\Resolved\Path\service-boilerplate
```