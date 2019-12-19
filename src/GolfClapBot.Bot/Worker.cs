using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PotatoSquad.Lib.Sliver.MessageObjects;

namespace GolfClapBot.Bot
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly SliverEventMonitor _sliverEventMonitor;

        public Worker(ILogger<Worker> logger, SliverEventMonitor sliverEventMonitor)
        {
            _logger = logger;
            _sliverEventMonitor = sliverEventMonitor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _sliverEventMonitor.AddChannel(new Streamer
            {
                Id = "usrubhd19i46epv1sdr"
            });

            _sliverEventMonitor.Start();
        }
    }
}