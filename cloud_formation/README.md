# Cloud Formation Demos
These CF templates serve as a tutorial for demonstrating how they are written.

**Do not use these templates as a baseline for production infrastructure.** Default values will be used for unspecified properties, which makes these templates unsuitable as boilerplate for building new infrastructure.

Be sure to look up the [resource reference](https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-template-resource-type-ref.html) for each AWS service so that all relevant properties are set.

---
**Note**

As a general rule, sensitive data like passwords or API keys should NOT be used in CloudFormation templates. There are too many ways for the data to be exposed. Some techniques do exist for encrypting parameters or reading sensitive data from AWS SSM, but look for other methods to pass the data first before using CloudFormation templates.

---