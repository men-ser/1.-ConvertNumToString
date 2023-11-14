namespace Конвертер_чисел_в_текст.Middleware
{
    public class FromElevenToNineteenMiddleware
    {
        private readonly RequestDelegate _next;

        public FromElevenToNineteenMiddleware(RequestDelegate next)
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
                string[] Numbers = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };


                if (number < 1000)
                {
                    string? result = string.Empty;
                    result = context.Session.GetString("num1hnd");
                    int num1 = Convert.ToInt32(context.Session.GetString("num1"));
                    if (number < 100)
                    {
                        if (number < 11 || number > 19)
                        {
                            await _next.Invoke(context);
                        }
                        else
                        {
                            await context.Response.WriteAsync("Your number is: " + Numbers[number - 11]);
                        }
                    }
                    else {

                        num1 %= 100;
                        if (num1 < 11 || num1 > 19)
                        {
                            await _next.Invoke(context);
                        }
                        else
                        {
                            await context.Response.WriteAsync("Your number is: " + result + " " + Numbers[num1 - 11]);
                        }
                    }

                }

                else {
                    string? result1 = context.Session.GetString("num1hnd");
                    string? result2 = context.Session.GetString("num2hnd");
                    int num1 = Convert.ToInt32(context.Session.GetString("num1"));
                    int num2 = Convert.ToInt32(context.Session.GetString("num2"));
                    num1 %= 100;
                    num2 %= 100;

                    if ((num1 < 11 || num1 > 19) && (num2 < 11 || num2 > 19))
                    {
                        await _next.Invoke(context);
                    }
                    else if (num1 < 11 || num1 > 19)
                    {
                        context.Session.SetString("num2elv", Numbers[num2 - 11]);
                        await _next.Invoke(context);
                    }

                    else if (num2 < 11 || num2 > 19)
                    {
                        context.Session.SetString("num1elv", Numbers[num1 - 11]);
                        await _next.Invoke(context);
                    }
                    else
                        await context.Response.WriteAsync("Your number is: " + Numbers[num2 - 11] + " thousand " + (result1!=null? result1 + " ":"") + Numbers[num1 - 11]);

               }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter");
            }
        }
    }
}
