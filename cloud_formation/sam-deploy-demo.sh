#!/usr/bin/env bash

# To exit after a command error, uncomment this line
# set -e

# These variables should be adjusted to your AWS account
# You'll need to create the DEPLOY_BUCKET to upload the CF template file
DEPLOY_BUCKET='my-deployment-bucket'
NEW_BUCKET_NAME='new-bucket-12345potato'
REGION='us-west-2'

deploy () 
{
    templateName=$1
    stackName=$2

    sam deploy -t "$templateName" \
        --stack-name $stackName \
        --s3-bucket $DEPLOY_BUCKET \
        --s3-prefix sam \
        --region $REGION \
        --parameter-overrides BucketName=$NEW_BUCKET_NAME \
        --capabilities CAPABILITY_IAM CAPABILITY_NAMED_IAM \
        --no-fail-on-empty-changeset 
}

# Pass the template name (source) and the target stack name without the environment here (destination)
deploy "03 - Bucket Parameter.yml" 'AWS-SAM-Deployment-demo'

# More deploy commands could be issued here

echo 'DONE'
read -p 'press enter'