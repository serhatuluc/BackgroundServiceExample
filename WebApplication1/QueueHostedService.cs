using WebApplication1.Queues;

namespace WebApplication1
{
    public class QueueHostedService:BackgroundService
    {
        private readonly ILogger<QueueHostedService> logger;
        private readonly IBackgroundTask<string> queue;
        public QueueHostedService(ILogger<QueueHostedService> logger, IBackgroundTask<string> queue)
        {
            this.logger = logger;
            this.queue = queue;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var name = await queue.DeQueue(stoppingToken);

                logger.LogInformation($"ExecuteAsync worked for {name}");
            }
        }
    }
}
