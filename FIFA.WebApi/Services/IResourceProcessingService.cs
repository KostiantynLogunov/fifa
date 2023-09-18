using FIFA.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FIFA.WebApi.Services
{
    public interface IResourceProcessingService
    {
        Task<List<Footballer>> ParseHtmlAsync(string html);

        Task<string> GetHtmlFromSourceAsync(string url);

        Task StoreDataToDbAsync(List<Footballer> footballers, CancellationToken token);
    }
}
