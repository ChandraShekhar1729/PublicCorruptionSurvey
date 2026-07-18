using Microsoft.AspNetCore.Http;
using PublicSurveyForm.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSurveyForm.Services.ImplementationService
{
    public class ClientInfoService :IClientInfoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientInfoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetIpAddress()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context is null)
                return "Unknown";

            // Handle reverse proxy / Azure App Service scenarios
            var forwardedFor = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(forwardedFor))
                return forwardedFor.Split(',').First().Trim();

            return context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
        }

        public async Task<string> GetBrowserName()
        {
            var context = _httpContextAccessor.HttpContext;
            var userAgent = context?.Request.Headers["User-Agent"].ToString();

            if (string.IsNullOrWhiteSpace(userAgent))
                return "Unknown";

            return await ParseBrowserName(userAgent);
        }

        public async Task<string> ParseBrowserName(string userAgent)
        {
            if (userAgent.Contains("Edg/")) return "Edge";
            if (userAgent.Contains("Chrome/") && !userAgent.Contains("Chromium")) return "Chrome";
            if (userAgent.Contains("Firefox/")) return "Firefox";
            if (userAgent.Contains("Safari/") && !userAgent.Contains("Chrome/")) return "Safari";
            if (userAgent.Contains("OPR/") || userAgent.Contains("Opera")) return "Opera";

            return "Other";
        }
    }
}
