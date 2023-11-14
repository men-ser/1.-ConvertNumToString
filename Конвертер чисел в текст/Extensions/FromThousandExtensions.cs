using ConvertNumToString.Middleware;

namespace ConvertNumToString.Extensions
{
    public static class FromThousandExtensions
    {
      
            public static IApplicationBuilder UseFromThousand(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<FromThousandMiddleware>();
            }
        
    }
}
