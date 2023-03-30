using RabbitMQ.Client;
using RabbitMQProducer;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
TopicExchangePublisher.Publish(channel);