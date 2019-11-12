using System;
#if UNITY_UWP
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
#endif
using System.Threading.Tasks;
using System.IO;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System.Text;

namespace VisionTwo
{
#if UNITY_UWP
    public static class VisionTwoHelper
    {
        static string subscriptionKey = "apikey";
        static string endpoint = "https://eastus.api.cognitive.microsoft.com/";

        public static string startAsync(byte[] photoBuffer)
        {
            // setting up endpoint
            var computerVision = Authenticate(endpoint, subscriptionKey);
            var task = Task.Run(async () => await ExtractTextLocal(computerVision, photoBuffer));
            return task.Result;
        }
        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
                new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
                { Endpoint = endpoint };
            return client;
        }

        public static async Task<string> ExtractTextLocal(ComputerVisionClient client, byte[] photoBuffer)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("EXTRACT TEXT - LOCAL IMAGE");
            Console.WriteLine();

            // Helps calucalte starting index to retrieve operation ID
            const int numberOfCharsInOperationId = 36;

            using (Stream imageStream = new MemoryStream(photoBuffer))
            {
                // Read the text from the local image
                BatchReadFileInStreamHeaders localFileTextHeaders = await client.BatchReadFileInStreamAsync(imageStream);
                // Get the operation location (operation ID)
                string operationLocation = localFileTextHeaders.OperationLocation;

                // Retrieve the URI where the recognized text will be stored from the Operation-Location header.
                string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

                // Extract text, wait for it to complete.
                int i = 0;
                int maxRetries = 10;
                ReadOperationResult results;
                do
                {
                    results = await client.GetReadOperationResultAsync(operationId);
                    Console.WriteLine("Server status: {0}, waiting {1} seconds...", results.Status, i);
                    await Task.Delay(1000);
                    if (maxRetries == 9)
                    {
                        Console.WriteLine("Server timed out.");
                    }
                }
                while ((results.Status == TextOperationStatusCodes.Running ||
                        results.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries);


                var textRecognitionLocalFileResults = results.RecognitionResults;
                StringBuilder stringBuilder = new StringBuilder();
                foreach (TextRecognitionResult recResult in textRecognitionLocalFileResults)
                {
                    foreach (Line line in recResult.Lines)
                    {
                        stringBuilder.Append(line.Text + " ");
                    }
                }
                return stringBuilder.ToString();
            }
        }
    }
#endif
}
