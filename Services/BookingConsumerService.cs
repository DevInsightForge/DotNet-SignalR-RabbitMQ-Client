using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Microsoft.AspNetCore.SignalR;
using test_dot.SignalR;
using System.Text;

namespace test_dot.Services
{
    public interface IBookingConsumerService
    {
        Task ReadBookings();
    }
    public class BookingConsumerService : IBookingConsumerService, IDisposable
    {
        private readonly IModel _model;
        private readonly IConnection _connection;
        private readonly INotificationHub _notifConn;

        public BookingConsumerService(IRabbitMqService rabbitMqService, INotificationHub notifConn)
        {
            _notifConn = notifConn;
            _connection = rabbitMqService.CreateChannel();
            _model = _connection.CreateModel();
            _model.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
            _model.ExchangeDeclare("booking", ExchangeType.Fanout, durable: true, autoDelete: false);
            _model.QueueBind(_queueName, "booking", string.Empty);
        }
        const string _queueName = "booking";
        public async Task ReadBookings()
        {
            var consumer = new AsyncEventingBasicConsumer(_model);
            consumer.Received += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var text = Encoding.UTF8.GetString(body);
                await _notifConn.SendNotification(text);
                await Task.CompletedTask;
                _model.BasicAck(ea.DeliveryTag, false);
            };
            _model.BasicConsume(_queueName, false, consumer);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_model.IsOpen)
                _model.Close();
            if (_connection.IsOpen)
                _connection.Close();
        }
    }
}
