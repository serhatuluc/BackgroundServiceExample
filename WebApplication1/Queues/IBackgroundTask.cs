namespace WebApplication1.Queues
{
    public interface IBackgroundTask<T>
    {
        ValueTask AddQueue(T workItem);

        ValueTask<T> DeQueue(CancellationToken cancellationToken);

    }
}
