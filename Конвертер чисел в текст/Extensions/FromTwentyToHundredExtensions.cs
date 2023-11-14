using Конвертер_чисел_в_текст.Middleware;

namespace Конвертер_чисел_в_текст.Extensions
{
    public static class FromTwentyToHundredExtensions
    {
        public static IApplicationBuilder UseFromTwentyToHundred(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromTwentyToHundredMiddleware>();
        }
    }
}
