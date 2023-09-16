using MediatR;
using Serilog;

namespace FIFA.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName=typeof(TRequest).Name;

            Log.Information("Footballer request: {Name} {@Request}",
                requestName, typeof(TRequest).Name);

            var response = await next();

            return response;
        }
    }
}
