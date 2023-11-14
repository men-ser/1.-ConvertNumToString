using Microsoft.AspNetCore.Http;

namespace Конвертер_чисел_в_текст.Middleware
{
    public class FromThousandMiddleware
    {
        private readonly RequestDelegate _next;

        public FromThousandMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"];
            try
            {
                int number = Convert.ToInt32(token);

                number = Math.Abs(number);
                if (number < 1000)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Session.SetString("thd", "thousand");
                    int num = (number - (number%1000))/1000;
                    context.Session.SetString("num2", num.ToString());
                    context.Session.SetString("num1", (number % 1000).ToString());

                   await _next.Invoke(context);
                  
                }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter");
            }
        }

    }
}
