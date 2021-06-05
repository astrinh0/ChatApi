using ChatApi.Infrastructure.Repos;
using ChatApi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.WorkServices
{
    public class CleanFiles : BackgroundService
    {
        private readonly ILogger<CleanFiles> _logger;
        private readonly IServiceProvider _services;


        public CleanFiles(ILogger<CleanFiles> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
          
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var fileRepository = scope.ServiceProvider.GetService<IFileRepository>();
                    await fileRepository.CheckTimeOfFile();
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
               
            }
        }
    }
}
