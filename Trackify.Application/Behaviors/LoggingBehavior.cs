using System;
using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Trackify.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request Name: {requestName}", typeof(TRequest).Name);
        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        var response = await next();
        stopwatch.Stop();

        _logger.LogInformation("Request Execution Time: {time}", stopwatch.Elapsed);


        return response;
    }
}
