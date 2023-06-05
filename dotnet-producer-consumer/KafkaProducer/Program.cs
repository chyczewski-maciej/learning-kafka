using Confluent.Kafka;

ProducerConfig config = new ProducerConfig { 
    BootstrapServers = "kafka.confluent:9092",
    ClientId = "test-producer"
};

using IProducer<Null, Int32> producer = new ProducerBuilder<Null, Int32>(config).Build();

String topic = "sample-topic";
Random random = new Random();

while(true) {
    Int32 message = random.Next(1, 40);
    DeliveryResult<Null, Int32> response = await producer.ProduceAsync(topic, new Message<Null, Int32> { Value = message });
    Console.WriteLine(response.Value);

    await Task.Delay(100);
}