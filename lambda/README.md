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
