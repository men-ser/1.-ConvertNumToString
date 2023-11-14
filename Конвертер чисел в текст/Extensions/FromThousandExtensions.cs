using Конвертер_чисел_в_текст.Middleware;

namespace Конвертер_чисел_в_текст.Extensions
{
    public static class FromThousandExtensions
    {
      
            public static IApplicationBuilder UseFromThousand(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<FromThousandMiddleware>();
            }
        
    }
}
