using Microsoft.AspNetCore.Http;
using System;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Hellang.Middleware.ProblemDetails
{
    /// <summary>
    /// Represents the enricher that enriches exception types assignable to TException />
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    public interface IProblemDetailsEnricher<TException>
        where TException : Exception
    {
        bool ShouldEnrich(HttpContext context, TException exception);
        void Enrich(HttpContext context, TException exception, MvcProblemDetails problem);
    }

    /// <summary>
    /// Represents the enricher that enriches all exception types
    /// </summary>
    public interface IProblemDetailsEnricher : IProblemDetailsEnricher<Exception>
    {
    }
}
