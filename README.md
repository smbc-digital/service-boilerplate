# Stockport WebAPI boilerplate.

This is the basis of a [custom .Net template](https://docs.microsoft.com/en-gb/dotnet/core/tools/custom-templates) it is used to generate restful WebApi project with default StockportGovUK setup and behaviours enabled.

# Required repos
* shared-gpg-keys
* internal-provisioning 

# Installation & Usage

## Installation From Nuget (recommended)

To register this application template with the dotnet cli 

```
dotnet new --install StockportGovUK.AspNetCore.BoilerPlate.Service
```
## Installation From Git/Folder

You also can register the template from a local directory  with the dotnet cli 

* Clone this repository to a folder locally or ensure you have the latest version pulled if you already have the repository cloned
* Navigate to the ```service-boilerplate/content``` folder
* install the the boilerplate using the --install switch

```
dotnet new --install .
```

## Checking your installation ##

Check that the template has been regsitered using the --list switch, check for the presence of "smbc-webapi" record.

```
dotnet new --list

SMBC WebApi boilerplate    smbc-webapi    [C#]     WebApi
```

## Using the boilerplate

If you've followed the steps above you can use the newly installed template with the dotnet new command.

```
dotnet new smbc-webapi
```

All generated files should match the name of your project, by default this will be the name of the folder in which the project has been created. If you want to the project to have a specific name you can use the -n switch.

```
dotnet new smbc-webapi -n mytestproject
```


# Mantaining this template

## Creating/Updating the Nuget package
To create a Nuget package for use as a template you __must__ use the Nuget CLI (as opposed to dotnet pack in the dotnet CLI). 

* [Install the CLI](https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools#nugetexe-cli).
* Navigate to folder cotaining the ```.nuspec``` file
* Call nuget pack

``` 
nuget pack
```

## Pushing a nuget package
You can use either the nuget CLI or the dotnet CLI to push the package. Below is the method for pushing the package using dotnet CLI.

```
dotnet nuget push StockportGovUK.AspNetCore.BoilerPlate.Service.#.#.#.nupkg -k <yourkeyhere> -s https://www.nuget.org
```



## Uninstalling the boilerplate
Should you wish to uninstall template you can do this using the --uninstall switch.

Note that you must provide the correct fully realised path to the folder from which the template was originally installed.

```
dotnet new --uninstall StockportGovUK.AspNetCore.BoilerPlate.Service
```

```
dotnet new --uninstall \C\The\Fully\Resolved\Path\service-boilerplate
```

## Update the readme
The boiler plate provides a default readme file, the readme file is important for providing context for the service and enable people to quickly onboard themselves when updating or fixing the service **please make sure you upate the readme file to reflect the usage and setup of your service**

## Make Setup
There are some additional scripts available within the boilerplate, which can perform certain tasks. When run, these ask a set of questions. These are all mandatory to complete the given task.
Please make sure you have the appropriate permissions to both Git and Team City before running these as the errors that occur aren't always the clearest.

Project setup including initalising git-crypt
```
make setup
```
It will then ask you to enter the path to your service
```
/c/Code/example-template-service
```
Then the remote SSH url of the repo
```
git@github.com:smbc-digital/example-template-service.git
```
And finally is the relative path to where you have you shared-gpg-keys folder cloned, if its in the Code folder it would just be:
```
../shared-gpg-keys
```

## Make Pipeline

The pipeline creation script has some requirments, they are listed within the make help command
```
make pipeline
```
It will ask for the relative path to where internal-provisioning is cloned, if its in the same folder as the gpg keys, this will just be:
```
../internal-provisioning
```
Then enter the SSH url again
```
git@github.com:smbc-digital/example-template-service.git
```
The project name as you want it to appear on TeamCity
```
Example Template Service
```
The Project Id
```
ExampleTemplateService
```
The Project Dll
```
example_template_service
```
And the sub app key
```
ExampleTemplateService
```

## Useful Resources
* [Dotnet new, command reference](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore22)
* [Custom template for dotnet new, Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates)
* [Dotnet new, templating home github](https://github.com/dotnet/templating)
* [Dotnet new, templating schema reference](https://github.com/dotnet/templating/wiki/Reference-for-template.json)
* [Blog: templates getting started](https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/)
