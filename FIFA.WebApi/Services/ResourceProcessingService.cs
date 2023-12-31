﻿using AngleSharp;
using AngleSharp.Dom;
using FIFA.Application.Interfaces;
using FIFA.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FIFA.WebApi.Services
{
    public class ResourceProcessingService: IResourceProcessingService
    {
        private readonly IServiceProvider _serviceProvider;
        public ResourceProcessingService(IServiceProvider serviceProvider) => _serviceProvider= serviceProvider;

        public async Task<string> GetHtmlFromSourceAsync(string url)
        {
            string responseHtml = string.Empty;

            try
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    HttpClient _httpClient =
                    scope.ServiceProvider.GetRequiredService<HttpClient>();

                    using HttpResponseMessage response = await _httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseHtml = await response.Content.ReadAsStringAsync();
                }

                return responseHtml;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Footballer>> ParseHtmlAsync(string html)
        {
            var footballers = new List<Footballer>();

            using var context = BrowsingContext.New();
            using var doc = await context.OpenAsync(req => req.Content(html));

            var trs = doc.QuerySelectorAll("tr.table-row");

            foreach (var tr in trs)
            {

                try
                {
                    var NameInLine = tr.QuerySelector("p.name b")?.InnerHtml;
                    var team = tr.QuerySelector("p.team a:nth-child(2)")?.InnerHtml;
                    //await Console.Out.WriteLineAsync($"{NameInLine} - {team}");

                    //string phrase = "The quick brown fox jumps over the lazy dog.";
                    if (string.IsNullOrEmpty(NameInLine))
                    {
                        continue;
                    }
                    string[] fullName = NameInLine.Split(' ');
                    
                    var footballer = new Footballer
                    {
                        Team = team
                    };

                    if (fullName.Count() ==1 )
                    {
                        footballer.FirstName = fullName[0];
                    }
                    if (fullName.Count() == 2)
                    {
                        footballer.LastName = fullName[1];
                    }

                    footballers.Add(footballer);
                }
                catch (Exception ex)
                {

                    throw;
                }
                    
            }

            return footballers.DistinctBy(p => p.FirstName).ToList();
        }

        public async Task StoreDataToDbAsync(List<Footballer> footballers, CancellationToken token)
        {
            footballers = footballers.DistinctBy(p=> p.FirstName).ToList() ;
            іif (footballers.Count() == 0)
            {
                return;
            }

            foreach (var footballer in footballers)
            {
                footballer.Id = Guid.NewGuid();
                footballer.CreatedAt = DateTime.Now;
                footballer.EditedAt = null;

                await Console.Out.WriteLineAsync($"{footballer.FirstName} {footballer.LastName} - Team: {footballer.Team}");
            }

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IFootballersDbContext _dbContext =
                scope.ServiceProvider.GetRequiredService<IFootballersDbContext>();

                await _dbContext.Footballers.AddRangeAsync(footballers);

                /*CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;*/

                await _dbContext.SaveChangesAsync(token);
            }
        }
    }
}
