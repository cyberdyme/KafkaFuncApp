using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Kafka;

namespace KafkaFuncApp
{
    public class KafkaTriggerFunc
    {
        [FunctionName("KafkaTriggerFunc")]
        public void Run(
            [KafkaTrigger("localhost:9094", "my-topic", ConsumerGroup = "az-func-group")]
            KafkaEventData<string>[] kafkaEvents,
            ILogger log)
        {
            foreach (var e in kafkaEvents)
            {
                log.LogInformation($"Kafka message: {e.Value}");
            }
        }
    }
}