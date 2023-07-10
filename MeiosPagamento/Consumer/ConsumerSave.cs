using System.Text;
using System.Text.Json;
using MeiosPagamento.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MeiosPagamento.Consumer
{
    public class ConsumerSave : IHostedService, IDisposable
    {

        private Timer _timer;
        private readonly IServiceProvider _services;
        public ConsumerSave(IServiceProvider services)
        {
            _services = services;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(3));

            return Task.CompletedTask;

        }

        private void DoWork(object state)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var pagamento = JsonSerializer.Deserialize<Pagamento>(message);

                using (var scope = _services.CreateScope())
                {
                    var pagamentoRepository = scope.ServiceProvider.GetRequiredService<IPagamentoRepository>();
                    pagamentoRepository.Create(pagamento);
                }

            };
            channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Close _connection
            _timer?.Dispose();
        }
    }
}
