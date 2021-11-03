# A sample project to demonstrate using Options pattern in ASP.NET Core (.NET 5)

Accessing an application configuration using IConfiguration service provided by ASP.NET Core which brings up an aggregate of appsettings json file along with several other providers, is simple and useful. 

As the application grows in complexity, the configuration too grows in most cases: new configurations and sections add up to the size of the appsettings making individual values from the appsettings hard to access.

An elegant solution for this is to "configure" these sections against their matching strongly typed classes and let ASP.NET Core handle the complexities for us.

We'll discuss the ways in which the appsettings JSON can be configured into a strongly typed object within the code and the differences between IOptions, IOptionsSnapshot and IOptionsMonitor. All using a simple and demonstrable example.

The complete explanation to this project is available at https://referbruv.com/blog/posts/working-with-options-pattern-in-aspnet-core-the-complete-guide
