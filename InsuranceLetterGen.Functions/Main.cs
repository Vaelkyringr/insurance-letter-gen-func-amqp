using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace InsuranceLetterGenService;

public class Main
{
    [FunctionName("Main")]
    public void Run([RabbitMQTrigger("Insurance", ConnectionStringSetting = "RabbitMQConnection")]string myQueueItem, ILogger log)
    {
        log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
    }
}
