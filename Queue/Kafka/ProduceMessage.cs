using Confluent.Kafka;

namespace GoodMarket.Queue.Kafka;

public class ProduceMessage
{
    public void CreateMessage(string messageInput) {
        var config = new ProducerConfig() {
            BootstrapServers = "localhost:9092",
            ClientId = "my-app",
            BrokerAddressFamily = BrokerAddressFamily.V4,
        };
        using
            var producer = new ProducerBuilder < Null, string > (config).Build();
        var input = Console.ReadLine();
        var message = new Message < Null, string > {
            Value = messageInput
        };
        producer.Produce("elastic-test", message);
    }
}