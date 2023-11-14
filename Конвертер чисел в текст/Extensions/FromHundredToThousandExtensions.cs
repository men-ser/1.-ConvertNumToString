using Конвертер_чисел_в_текст.Middleware;

namespace Конвертер_чисел_в_текст.Extensions
{
    public static class FromHundredToThousandExtensions
    {
        public static IApplicationBuilder UseFromHundredToThousand(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromHundredToThousandMiddleware>();
        }

    }
}
