using System.Collections.Concurrent;

namespace WotchHomeTask.API
{
    public class BackgroundRequestQueue
    {
        private ConcurrentQueue<object> _requestData = new();
        private SemaphoreSlim _signal = new SemaphoreSlim(DataProcessor.DataProcessor.MaxConcurrentCalls,5);
        public async Task ProcessDataAsync(CancellationToken cancellationToken)
        {
            while (!_requestData.IsEmpty)
            {
                await _signal.WaitAsync(cancellationToken);
                try
                {
                    
                    _requestData.TryPeek(out var next);
                    DataProcessor.DataProcessor.ProcessData(next);
                    _requestData.TryDequeue(out _);
                    Console.WriteLine("data procsess has been finished,Dequeue from queue");
                   
                }
                finally
                {
                    _signal.Release();

                }

            }
        }


        public void QueueBackgroundWorkItem(object data)
        {
            if (_requestData == null)
            {
                throw new ArgumentNullException(nameof(_requestData));
            }

            _requestData.Enqueue(data);

        }
    }
}
