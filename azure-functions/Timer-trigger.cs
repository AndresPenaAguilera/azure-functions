using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace azure_functions
{
    public static class Timer_trigger
    {
        [FunctionName("Timer_trigger")]
        //public static void Run([TimerTrigger("*/3 * * * * *")] TimerInfo myTimer, ILogger log)
        public static void Run([TimerTrigger("00:00:03")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
