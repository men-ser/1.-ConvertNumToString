using Конвертер_чисел_в_текст.Middleware;

namespace Конвертер_чисел_в_текст.Extensions
{
    public static class FromElevenToNineteenExtensions
    {
        public static IApplicationBuilder UseFromElevenToNineteen(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromElevenToNineteenMiddleware>();
        }

    }
}
