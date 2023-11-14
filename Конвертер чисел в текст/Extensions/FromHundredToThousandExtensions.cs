using ConvertNumToString.Middleware;

namespace ConvertNumToString.Extensions
{
    public static class FromHundredToThousandExtensions
    {
        public static IApplicationBuilder UseFromHundredToThousand(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromHundredToThousandMiddleware>();
        }

    }
}
