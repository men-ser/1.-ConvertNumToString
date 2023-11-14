using Конвертер_чисел_в_текст.Middleware;

namespace Конвертер_чисел_в_текст.Extensions
{
    public static class FromOneToTenExtensions
    {
        public static IApplicationBuilder UseFromOneToTen(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromOneToTenMiddleware>();
        }
    }
}
