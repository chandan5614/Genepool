using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Genepool.Architectures.CleanArchitecture.Logging.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation("Handling {RequestName} {@Request}", requestName, request);

            var response = await next(); // Call the next handler

            stopwatch.Stop();

            _logger.LogInformation("Handled {RequestName} in {ElapsedMilliseconds} ms - Response: {@Response}", 
                requestName, stopwatch.ElapsedMilliseconds, response);

            return response;
        }
    }
}
