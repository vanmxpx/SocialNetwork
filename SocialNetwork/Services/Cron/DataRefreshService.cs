using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Cron
{
    public class DataRefreshService : HostedService
    {
        private readonly ProfileRemoveProvider _randomStringProvider;

        public DataRefreshService(ProfileRemoveProvider randomStringProvider)
        {
            _randomStringProvider = randomStringProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await _randomStringProvider.Do(cancellationToken);
                await Task.Delay(TimeSpan.FromMinutes(2), cancellationToken);
            }
        }
    }
}