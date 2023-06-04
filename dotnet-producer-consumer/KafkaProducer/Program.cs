using Confluent.Kafka;

ProducerConfig config = new ProducerConfig { 
    BootstrapServers = "kafka.confluent:9092",
    ClientId = "test-producer"
};

ProducerBuilder<Null, string> producerBuilder = new ProducerBuilder<Null, string>(config);
IProducer<Null, string> producer = producerBuilder.Build();

var topic = "some-topic";

while(true) {
    var message = $"Hello World at {DateTime.Now}";
    DeliveryResult<Null, string> response = await producer.ProduceAsync(topic, new Message<Null, String> { Value = message });
    Console.WriteLine(response.Value);

    await Task.Delay(1_000);
}
