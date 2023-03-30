using System;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQConsumer2
{
    public class TopicExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("contoh-topic-exchange", ExchangeType.Topic);
            channel.QueueDeclare("contoh-topic-queue2",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            channel.QueueBind("contoh-topic-queue2", "contoh-topic-exchange", "student.*");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("contoh-topic-queue2", true, consumer);
            Console.WriteLine("Aplikasi consumer dijalankan...");
            Console.ReadLine();
        }
    }
}