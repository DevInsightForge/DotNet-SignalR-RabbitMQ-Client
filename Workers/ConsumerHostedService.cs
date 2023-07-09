using test_dot.Services;

namespace test_dot.Workers
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IBookingConsumerService _consumerService;

        public ConsumerHostedService(IBookingConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumerService.ReadBookings();
        }
    }
}
