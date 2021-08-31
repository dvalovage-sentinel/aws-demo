# Cloud Formation Demos
These CF templates serve as a tutorial for demonstrating how they are written.

**Do not use these templates as a baseline for production infrastructure.** Default values will be used for unspecified properties, which makes these templates unsuitable as boilerplate for building new infrastructure.

Be sure to look up the [resource reference](https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-template-resource-type-ref.html) for each AWS service so that all relevant properties are set.

---
**Note**

As a general rule, sensitive data like passwords or API keys should NOT be used in CloudFormation templates. There are too many ways for the data to be exposed. Some techniques do exist for encrypting parameters or reading sensitive data from AWS SSM, but look for other methods to pass the data first before using CloudFormation templates.

---
## Goal
These templates are designed for two purposes:
* A simple walkthrough for beginners to CloudFormation templates
* A quick reference for "how to do X"

## Deployment
To deploy your CloudFormation templates, you can use the command line for the [AWS Serverless Application Model (AWS SAM)](https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/sam-cli-command-reference-sam-deploy.html). You'll need to [install](https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/serverless-sam-cli-install.html) the AWS SAM command line interface.

The `sam-deploy-demo.sh` bash script demonstrates how the AWS SAM CLI can be invoked. Note that if the guided mode is enabled (with the `--guided` or `-g` flag), a separate stack for managing SAM deployments will also be created in the target account.

Alternatively you can use the older [AWS CLI](https://docs.aws.amazon.com/cli/?id=docs_gateway), which requires more code to be written for handling the upload and monitoring of the CloudFormation template. See the documentation for the `aws cloudformation` command [located here](https://awscli.amazonaws.com/v2/documentation/api/latest/reference/cloudformation/index.html).