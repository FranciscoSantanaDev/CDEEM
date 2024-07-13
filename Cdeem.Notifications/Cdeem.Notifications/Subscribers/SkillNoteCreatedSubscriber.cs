using Cdeem.API.Infrastructure;
using Cdeem.Notification.Model;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data.Common;
using System.Text;
using System.Threading.Channels;

namespace Cdeem.Notifications.API.Subscribers
{
    public class SkillNoteCreatedSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "notifications-service/Skill-Note-Created";
        private const string RoutingKeySubscribe = "Skill-Note-Created";
        private readonly IServiceProvider _serviceProvider;
        private const string TrackingsExchange = "Cdeem-service";
        public SkillNoteCreatedSubscriber(IServiceProvider serviceProvider) 
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            _connection = connectionFactory.CreateConnection("Skill-Note-Created-consumer");

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(TrackingsExchange, "topic", true, false);

            _channel.QueueDeclare(
                queue: Queue,
            durable: true,
            exclusive: false,
                autoDelete: false);

            _channel.QueueBind(Queue, TrackingsExchange, RoutingKeySubscribe);

            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var @event = JsonConvert.DeserializeObject<SkillNoteCreatedEvent>(contentString);

                Console.WriteLine($"Message SkillNoteCreatedEvent received");

                Notify(@event).Wait();

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }
        public async Task Notify(SkillNoteCreatedEvent @event)
        {
            using var scope = _serviceProvider.CreateScope();

            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

            var template = new SkillNoteCreatedTemplate(@event.ContactEmail, @event.Annotation, @event.SkillTitle);

            await notificationService.Send(template);
        }
    }
}
