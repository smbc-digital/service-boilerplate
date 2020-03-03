# Stockport WebAPI boilerplate.

This is the basis of a [custom .Net template](https://docs.microsoft.com/en-gb/dotnet/core/tools/custom-templates) it is used to generate restful WebApi project with default StockportGovUK setup and behaviours enabled.

# Installation & Usage

## Installation From Nuget (recommended)

To register this application template with the dotnet cli 

```
dotnet new --install StockportGovUK.AspNetCore.BoilerPlate.Service
```
## Installation From Git/Folder

You also can register the template from a local directory  with the dotnet cli 

* Clone this repository to a folder locally
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

## Makefile
There are some additional scripts available within the boilerplate, which can perform certain tasks. They are as follows:

Project setup including initalising git-crypt
```
make setup
```

Pipeline creation:

The pipeline creation script has some requirments, they are listed within the make help command
```
make pipeline
```

## Useful Resources
* [Dotnet new, command reference](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore22)
* [Custom template for dotnet new, Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates)
* [Dotnet new, templating home github](https://github.com/dotnet/templating)
* [Dotnet new, templating schema reference](https://github.com/dotnet/templating/wiki/Reference-for-template.json)
* [Blog: templates getting started](https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/)

## Instructions to create new micro service to be used for form builder forms.
* Create a new service using this boiler plate: dotnet new smbc-webapi -n [formname]service
* launchSettings.json: Change the port numbers to be unique to this service and amend launchUrl: "swagger"
* appsettings.secrets.json:  "TokenAuthentication:Key": "[guidfromformjson]"
* appsettings.json: add HttpClientConfiguration settings for VerintServiceGateway
* Startup.cs: usings:
```
using deletemeservice.Utils.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockportGovUK.AspNetCore.Availability;
using StockportGovUK.AspNetCore.Middleware;
using StockportGovUK.NetStandard.Gateways;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
```
```
public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddMvcOptions(o => o.AllowEmptyInputInBodyModelBinding = true);
            services.AddHealthChecks()
                .AddCheck<TestHealthCheck>("TestHealthCheck");
            services.AddAvailability();
            services.AddResilientHttpClients<IGateway, Gateway>(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "deletemeservice API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Authorization using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseMiddleware<ExceptionHandling>();
            app.UseHttpsRedirection();
            app.UseHealthChecks("/healthcheck", HealthCheckConfig.Options);
            app.UseMvc();
            app.UseSwagger();
            var swaggerPrefix = env.EnvironmentName == "local" ? string.Empty : "/[servicename]";
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{swaggerPrefix}/swagger/v1/swagger.json", "[servicename] API");
            });
        }
```
* HomeController.cs: Post: 
```
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]object model)
        {
            _logger.LogDebug(JsonConvert.SerializeObject(model));
            try
            {
                //var result = await _crmService.CreateCase(model);
                return Ok();//
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"HomeController an exception has occured, ex: {ex}");
                return StatusCode(500, ex);
            }
        }
```
* At this point you should be able to run the service and be met with the swagger page. The homecontroller post enpoint will accept any json sent to it and return an OK back to the form builder if hit. We want to accept an object/json of data and apply it to a model. Steps to do this are coming.
* To convert the json coming from the form builder to the model needed for the service: Complete the form as normal and submit the data to the existing Post in the service. Inspect the model that's been recieved.
```
{{  "firstName": "ffffff",  "lastName": "llllll",  "email": "asdf@asdf.com",  "phone": "32233223",  "addresslineone": "aaaaaaaa",  "addresslinetwo": "bbbbbbbbb",  "town": "ttttttt",  "postcode": "sk2 4dd"}}
```
* Remove the outer {} and paste into http://json2csharp.com/ and click convert. This should create:
```
public class RootObject
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string addresslineone { get; set; }
    public string addresslinetwo { get; set; }
    public string town { get; set; }
    public string postcode { get; set; }
}
```
* Rename the RootObject to the Model you want to store the data in (ReportAnIssue). Place this in a folder called Model and then change the Post to 
```     
public async Task<IActionResult> Post([FromBody]ReportAnIssue model)
```

* You'll then perhaps want to add in a crmservice to push the data to verint. 
