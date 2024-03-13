using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using Skeleton.Application.Shared;

namespace Skeleton.Application.Behaviours
{
    public sealed class LoggingBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            Log.Information("Starting Request {@RequestName},{@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

            var result = await next();

            if (result.IsFailue)
            {
                var failure = result as Result;

                Log.Error("Request {@RequestName} failed: {@ErrorMessage},{@DateTimeUtc}",
                    typeof(TRequest).Name,
                    failure.Error,
                    DateTime.UtcNow);
            }

            Log.Information("Completed Request {@RequestName},{@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

            return result;
        }
    }
}
