using MassTransit;
using Worker;

namespace Application
{
    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               // await _bus.Publish(new WorkerQueue { Val = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
