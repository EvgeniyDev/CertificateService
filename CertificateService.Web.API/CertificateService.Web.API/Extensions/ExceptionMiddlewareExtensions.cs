﻿using CertificateService.Web.API.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace CertificateService.Web.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}