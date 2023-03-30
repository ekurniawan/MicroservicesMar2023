using RabbitMQ.Client;
using RabbitMQConsumer;


var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

TopicExchangeConsumer.Consume(channel);