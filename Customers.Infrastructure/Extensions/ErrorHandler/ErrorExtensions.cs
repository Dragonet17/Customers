using Microsoft.AspNetCore.Builder;

namespace Customers.Infrastructure.Extensions.ErrorHandler {
    public static class ErrorExtensions {
        public static IApplicationBuilder UseErrorHandlerMiddleware (this IApplicationBuilder appBuilder) =>
            appBuilder.UseMiddleware (typeof (ErrorHandlerMiddleware));
    }
}