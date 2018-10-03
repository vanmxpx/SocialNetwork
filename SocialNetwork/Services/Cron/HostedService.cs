using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Cron{    
public abstract class HostedService : IHostedService
{

    private Task executingTask;
    private CancellationTokenSource cts;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        executingTask = ExecuteAsync(cts.Token);
        return executingTask.IsCompleted ? executingTask : Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if (executingTask == null)
        {
            return;
        }

        cts.Cancel();
        await Task.WhenAny(executingTask, Task.Delay(-1, cancellationToken));
        cancellationToken.ThrowIfCancellationRequested();
    }
    protected abstract Task ExecuteAsync(CancellationToken cancellationToken);
}

}
