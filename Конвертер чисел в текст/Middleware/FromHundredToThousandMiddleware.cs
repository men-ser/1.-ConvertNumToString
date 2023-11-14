using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Eventing.Reader;

namespace Конвертер_чисел_в_текст.Middleware
{
    public class FromHundredToThousandMiddleware
    {
        private readonly RequestDelegate _next;

        public FromHundredToThousandMiddleware(RequestDelegate next)
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
                string[] Numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                //string? result1 = string.Empty;
                //string? result2 = string.Empty;
                //string? result3 = string.Empty;
                //string? result = string.Empty;
                
                if (number <1000)
                {
                    int num1;   //
                    if (number < 100)
                    {
                        await _next.Invoke(context);
                    }
                    else
                    {
                        num1 = (number - number % 100)/100;
                        

                        context.Session.SetString("num1hnd", Numbers[num1-1] + " hundred");
                        context.Session.SetString("num1", number.ToString());

                        await _next.Invoke(context);

                    }
                }
                else {
                    int num1 = Convert.ToInt32(context.Session.GetString("num1"));
                    int num2 = Convert.ToInt32(context.Session.GetString("num2"));

                    if (num1 < 100 && num2 < 100) { await _next.Invoke(context); }
                    else if (num1 >0 && num1 < 100 && num2 == 100)
                    {
                        context.Session.SetString("num2hnd", "one hundred");
                        context.Session.SetString("num2", num2.ToString());

                        await _next.Invoke(context);
                    }
                    else if (num1 ==0 && num2 == 100)
                        await context.Response.WriteAsync("Your number is: one hundred thousand");
                    else
                    {
                        context.Session.SetString("num1", num1.ToString());
                        num1 = (num1 - num1 % 100) / 100;
                        context.Session.SetString("num1hnd", Numbers[num1 - 1] + " hundred");
                        await _next.Invoke(context);
                    }


                }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter");
            }
        }
    }
}
