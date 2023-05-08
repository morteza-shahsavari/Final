using Microsoft.AspNetCore.Http;

namespace EShopMashtiHasan.Utility
{
    public static class RequestExtensions
    {

        public static bool IsMobileBrowser(this HttpRequest request)
        {
            var userAgent = request.UserAgent();
            if ((Constants.OS.IsMatch(userAgent) || Constants.device.IsMatch(userAgent.Substring(0, 4))))
            {
                return true;
            }

            return false;
        }

        public static string UserAgent(this HttpRequest request)
        {
            return request.Headers["User-Agent"];
        }
    }
}
