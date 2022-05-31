using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;

namespace azure_functions.Http_trigger
{
    public static class EmailSender
    {
        [FunctionName("EmailSender")]
        public static async Task<IActionResult> Run(

            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
                Email email,
            
            [SendGrid(ApiKey ="SendGridApiKey")]
                IAsyncCollector<SendGridMessage> collector,

            ILogger log 
        )
        {

            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("p.andres01@hotmail.com");
            sendGridMessage.AddTo(email.To);
            sendGridMessage.AddContent("text/html", email.Body);
            sendGridMessage.SetSubject(email.Subject);

            collector.AddAsync(sendGridMessage);

            return new OkObjectResult("Email sent to { to }");
        }
    }

    public class Email 
    { 
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
