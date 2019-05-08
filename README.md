# Stockport WebAPI boilerplate.

A standard boilerplate used to generate Restful micro services with default Stockport setup and behaviours.

## Installation

To register this application template with the dotnet cli 

* Navigate to the boiler root boilerplate folder
* install the the boilerplate using;

```
dotnet new --install .
```

* Check that the template has been regsitered using the --list switch, check for the presence of "smbc-webapi" record.

```
dotnet new --list

SMBC WebApi boilerplate    smbc-webapi    [C#]     WebApi
```

## Using the boilerplate

If you've followed the steps above you should be good to go and can use the newly installed template.

```
dotnet new smbc-webapi
```

All teh generated files are should match the name of your project, by default, this will be the name of the folder in which the project has been created. If you want to the project to have a specific name you can use the -n switch.

```
dotnet new smbc-webapi -n mytestproject
```

## Unistalling the boilerplate
Should you wish to uninstall template you can do this using the --uninstall switch.

Note that you must provide the correct fully realised path to the folder from which the template was originally installed.

```
dotnet new --uninstall \C\The\Fully\Resolved\Path\service-boilerplate
```

