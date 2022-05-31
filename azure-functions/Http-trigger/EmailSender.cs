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
        public static IActionResult Run(

            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "emails")]
                Email email,
            
            [SendGrid(ApiKey ="SendGridApiKey",
                      From ="p.andres01@hotmail.com", 
                      Subject = "{ Subject }",
                      To = "{ To }",
                      Text = "{ Body }"
            )]
                out SendGridMessage sendGridMessage,

            ILogger log 
        )
        {
            sendGridMessage = new SendGridMessage();

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
