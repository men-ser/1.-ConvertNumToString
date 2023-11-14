using ConvertNumToString.Middleware;

namespace ConvertNumToString.Extensions
{
    public static class FromTwentyToHundredExtensions
    {
        public static IApplicationBuilder UseFromTwentyToHundred(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromTwentyToHundredMiddleware>();
        }
    }
}
