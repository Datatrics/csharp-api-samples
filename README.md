![Datatrics](https://www.datatrics.com/wp-content/themes/datatrics/assets/img/logo/logo.png)

# Datatrics C# API samples
This package is a sample library to communicate with the Datatrics REST-API.

## Installation
For the installation of the samples you need to run this nuget command.

``` bash
Install-Package datatrics-csharp-api
```

## Usage
Copy the contents of config.php.dist to config.php and fill the apiKey and projectId variables.

```csharp
use Datatrics;

Client client = new Client("[api-key]", "[project-id]");
Content content = await client.Content.Get("contentid-1");
```

__Explanation__

[api-key]
The API key you've received or created

[project-id]
id of the project

## Contributing
We love contributions, but please note that the API client is generated. If you have suggested changes, you may still create a PR, but your PR will not be merged. We will however adapt the generator to reflect your changes. You can also create a GitHub issue if there's something you miss.
