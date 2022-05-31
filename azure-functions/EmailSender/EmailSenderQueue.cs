using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;

namespace azure_functions.EmailSender
{
    public static class EmailSenderQueue
    {
        [FunctionName("EmailSenderQueue")]
        [return: SendGrid(ApiKey = "SendGridApiKey",
                      From = "p.andres01@hotmail.com",
                      Subject = "{ Subject }",
                      To = "{ To }",
                      Text = "{ Body }"
            )]
        public static SendGridMessage Run(
            
            [QueueTrigger("emails", Connection = "AzureWebJobsStorage")]
                Email email,

            ILogger log
            
            )
        {
           return new SendGridMessage();
        }
    }
}
