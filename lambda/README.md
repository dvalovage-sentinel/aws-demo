# Lambda Demos

## 1. LambdaDemo1

This is a barebones demonstration of what is required to develop Lambdas in C#. Using the .NET Core 3.1 framework, we can create a normal C# .NET Core project ("`dotnet new ...`") with the the following additions:

* The `GenerateRuntimeConfigurationFiles` property is set to `true` in the .csproj file
* A `LambdaSerializer` is set either for the entire assembly or for each handler invoked by AWS

To update the Lambda, publish the project and zip up the output. You can upload either directly to the Lambda or to an accessible S3 bucket and update the Lambda from there using the AWS interface.

If you have [7zip](https://www.7-zip.org/) installed and referenced in your PATH, you can use the following commands to generate the zip file:

```
dotnet publish -c Release
7z a bin\upload.zip ".\bin\Release\netcoreapp3.1\publish\*"
```
The zip file can then be manually uploaded to a new Lambda created in the AWS interface.

## 2. LambdaDemo2
This project was created from the [AWS CLI](https://docs.aws.amazon.com/lambda/latest/dg/csharp-package-cli.html) using the following command:
```
dotnet new lambda.EmptyFunction --name LambdaDemo2
```
We've also implemented a custom serializer for the input and output streams to the Lambda. Take a look at the `UpperCaseLambdaJsonSerializer` class to see how an example of how to do this.

This project may deployed using the following command:
```
dotnet lambda deploy-function lambdademo2 --function-role AWSLambdaDynamoDBExecutionRole
```

## LambdaDemo3
This project was created via the [Serverless Framework](https://www.serverless.com/framework/docs/providers/aws/).

Building and deploying is straightforward:
```
./build.cmd
serverless deploy
```

Unlike the previous two demos, this Lambda is actually deployed through CloudFormation (infrastructure as code; see [this explanation](https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/Welcome.html)). This ensures uniform deployment and works well with CI/CD pipelines.

## LambdaDemo4
This project was created and deployed with the [AWS Serverless Application Model (SAM)](https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/what-is-sam.html). **This is distinct from the Serverless Framework used in LambdaDemo3**.

The commands are similar to Serverless:
```
sam build
sam deploy --guided
```

There are subtle differences between the two frameworks, however. AWS SAM template syntax is derived from CloudFormation, and Serverless has its own syntax. SAM will be only compatible with AWS, whereas Serverless offers configuration and deployment compatible with other cloud vendors such as Azure, Google, and others.

## LambdaDemo5
This example illustrates a new possibility with Lambdas: deploying containers to customize the runtime environment.

The code was generated from a [.NET blueprint](https://github.com/aws/aws-lambda-dotnet/tree/master/Blueprints/BlueprintDefinitions/netcore3.1/EmptyFunction-Image/template/src/BlueprintBaseName.1).

New project:
```
dotnet new lambda.image.EmptyFunction -n LambdaDemo5
```
Deployment:
```
dotnet lambda deploy-function
```
This allows us to run custom runtimes, which in this case included .NET 5 (which is otherwise unavailable to Lambdas at the time of this writing).

## LambdaDemo6
This example shows how to implement ASP<area>.NET Core Serverless into a Serverless (.com) project.

The principal differences from previous demos with Serverless are:

1. Adding the package reference for ASP<area>.NET Core Server into the csproj file:
        
        <PackageReference Include="Amazon.Lambda.AspNetCoreServer" Version="6.0.3" />

1. The `LambdaEntryPoint` class inherits from `APIGatewayHttpApiV2ProxyFunction` to integrate with the AWS HTTP API.
1. The Serverless template uses HTTP API in its mark up (denoted as `httpApi` under the event).
1. The requisite `Startup` and Controller classes must be included and registered properly using ASP<area>.NET Core wiring.

Using this setup with a wildcard mapping for the HTTP API pushes all routing back to the Lambda, which handles request marshalling internally.

The older AWS REST API can still be used with the `http` event tag in the Serverless template. However a different base class in the entry point must be used in conjunction with this or a null reference will be thrown. See `LambdaEntryPoint.cs` for further explanation.