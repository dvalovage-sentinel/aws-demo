# Lambda Demos

## 1. LambdaDemo1

This is a barebones demonstration of what is required to develop Lambdas in C#. Using the .NET Core 3.1 framework, we can create a normal C# project ("`dotnet new ...`") with the the following additions:

* The `GenerateRuntimeConfigurationFiles` property is set to `true` in the .csproj file
* A `LambdaSerializer` is set either for the entire assembly or for each handler invoked by AWS

To update the Lambda, publish the project and zip up the output. You can upload either directly to the Lambda or to an accessible S3 bucket and update the Lambda from there using the AWS interface.

If you have [7zip](https://www.7-zip.org/) installed and referenced in your PATH, you can use the following commands to generate the zip file:

```
dotnet publish -c Release
7z a bin\upload.zip ".\bin\Release\netcoreapp3.1\publish\*"
```

## 2. LambdaDemo2
