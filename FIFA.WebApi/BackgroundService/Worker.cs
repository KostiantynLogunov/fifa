using System.Threading.Tasks;
using System.Threading;
using BS = Microsoft.Extensions.Hosting.BackgroundService;
using System;
using FIFA.WebApi.Services;
using FIFA.Domain;
using System.Collections.Generic;

namespace FIFA.WebApi.BackgroundService
{
    public class Worker: BS
    {
        private readonly IResourceProcessingService _resourceProcessingService;
        public Worker(IResourceProcessingService resourceProcessingService) => _resourceProcessingService = resourceProcessingService;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //await Console.Out.WriteLineAsync("backgroud worker is starting work...");

            List<Footballer> generalFootballerList = new List<Footballer>();

            var addr = "https://www.futwiz.com/en/fifa23/players?page=";

            var pages = 800;

            for (int i = 0; i <= pages; i++)
            {
                string address = addr + i.ToString();
                await Console.Out.WriteLineAsync(   $"========================================           {i}");
                string html = await _resourceProcessingService.GetHtmlFromSourceAsync(address);

                List<Footballer> footballers = await _resourceProcessingService.ParseHtmlAsync(html);   

                generalFootballerList.AddRange(footballers);

                /*if (generalFootballerList.Count() >= 200)
                {
                    await _resourceProcessingService.StoreDataToDbAsync(generalFootballerList);
                    generalFootballerList = new List<Footballer>();
                }*/

                await Task.Delay(200);
            }

            await _resourceProcessingService.StoreDataToDbAsync(generalFootballerList, stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Console.Out.WriteLineAsync($"Worker running at: {DateTimeOffset.Now}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
