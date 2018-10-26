using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.S3Events;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace CodeRunner.Warp4.CustomFunction
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void FunctionHandler(S3Event input, ILambdaContext context)
        {
            foreach (var record in input.Records)
                context.Logger.Log($"Bucket: {record.S3.Bucket.Name}, Key: {record.S3.Object.Key}");
        }
    }
}
