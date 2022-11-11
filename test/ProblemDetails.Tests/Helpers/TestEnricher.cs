using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using System;

namespace ProblemDetails.Tests.Helpers
{
    internal sealed class TestEnricher : IProblemDetailsEnricher<ArgumentException>
    {
        public string TestExceptionData { get; }
        public string EnrichedPropertyName => "StandaloneEnricher";

        public TestEnricher(string testExceptionData)
        {
            TestExceptionData = testExceptionData;
        }

        public void Enrich(HttpContext context, ArgumentException exception, Microsoft.AspNetCore.Mvc.ProblemDetails problem)
        {
            problem.Extensions.Add(EnrichedPropertyName, TestExceptionData);
        }

        public bool ShouldEnrich(HttpContext context, ArgumentException exception)
            => exception.ParamName == TestExceptionData;
    }
}
