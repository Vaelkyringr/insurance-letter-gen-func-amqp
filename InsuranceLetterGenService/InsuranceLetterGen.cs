using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace InsuranceLetterGenService;

public class InsuranceLetterGen
{
    [FunctionName("Function1")]
    public void Run([RabbitMQTrigger("Insurance", ConnectionStringSetting = "testest")]string myQueueItem, ILogger log)
    {
        log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
    }
}
