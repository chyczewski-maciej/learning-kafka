using Confluent.Kafka;

ConsumerConfig consumerConfig = new ConsumerConfig()
{
    GroupId = "sample-topic-consumer-group-1",
    BootstrapServers = "kafka.confluent:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Null, Int32>(consumerConfig).Build();
consumer.Subscribe("sample-topic");

while (true)
{
    ConsumeResult<Null, Int32> response = consumer.Consume(CancellationToken.None);
    if (response == null)
    {
        Console.WriteLine("No message received. Waiting 5 seconds...");
        await Task.Delay(TimeSpan.FromSeconds(5));
        continue;
    }

    Int64 value = response.Message.Value;
    Int64 fib = Fibbonacci(value);
    Console.WriteLine($"Fibbonacci({value}) = {fib}");
}

// Intentinally computation heavy function to observe the behavior of the consumer group
Int64 Fibbonacci(Int64 n)
{
    if (n <= 1)
        return n;

    return Fibbonacci(n - 1) + Fibbonacci(n - 2);
}
