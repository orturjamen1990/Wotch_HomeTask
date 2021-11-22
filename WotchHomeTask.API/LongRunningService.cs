namespace WotchHomeTask.API
{
    public class LongRunningService : BackgroundService
    {
        private readonly BackgroundRequestQueue queue;

        public LongRunningService(BackgroundRequestQueue queue)
        {
            this.queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await queue.ProcessDataAsync(stoppingToken);
            }
        }
    }
}


