using Confluent.Kafka;

ConsumerConfig consumerConfig = new ConsumerConfig()
{
    GroupId = "some-topic-consumer-group-1",
    BootstrapServers = "kafka.confluent:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Null, String>(consumerConfig).Build();
consumer.Subscribe("some-topic");


while (true)
{
    ConsumeResult<Null, string> response = consumer.Consume(CancellationToken.None);
    if(response == null)
    {
        Console.WriteLine("No message received. Waiting 5 seconds...");
        await Task.Delay(TimeSpan.FromSeconds(5));
        continue;
    }

    Console.WriteLine(response.Message.Value);
}
