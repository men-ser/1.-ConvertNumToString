namespace ConvertNumToString.Middleware
{
    public class FromTwentyToHundredMiddleware
    {
        private readonly RequestDelegate _next;

        public FromTwentyToHundredMiddleware(RequestDelegate next)
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
                string[] Numbers = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 1000)
                {
                    string? result = string.Empty;
                    result = context.Session.GetString("num1hnd");

                    if (result == null)
                    {
                        if (number < 20)
                        {
                            await _next.Invoke(context);
                        }
                        else
                        {
                            number /= 10;
                            context.Session.SetString("num1ten", Numbers[number - 2]);
                            await _next.Invoke(context);
                        }
                    }
                    else
                    {

                        int num1 = Convert.ToInt32(context.Session.GetString("num1"));
                        num1 %= 100;
                        if (num1 < 20)
                        {
                            await _next.Invoke(context);
                        }
                        else
                        {
                            num1 /= 10;
                            context.Session.SetString("num1ten", Numbers[num1 - 2]);
                            await _next.Invoke(context);
                        }
                    }

                }

                else
                {
                    string? result1 = context.Session.GetString("num1hnd");
                    string? result2 = context.Session.GetString("num2hnd");
                    int num1 = Convert.ToInt32(context.Session.GetString("num1"));
                    int num2 = Convert.ToInt32(context.Session.GetString("num2"));
                    num1 %= 100;
                    num2 %= 100;

                        if ((num1 < 20) && (num2 < 20))
                        {
                            await _next.Invoke(context);
                        }
                        else if (num1 < 20)
                        {
                            num2 /= 10;
                            context.Session.SetString("num2ten", Numbers[num2 - 2]);
                            await _next.Invoke(context);
                        }

                        else if (num2 < 20)
                        {
                            num1 /= 10;
                            context.Session.SetString("num1ten", Numbers[num1 - 2]);
                            await _next.Invoke(context);
                        }
                        else
                        {
                            num1 /= 10; num2 /= 10;
                            context.Session.SetString("num1ten", Numbers[num1 - 2]);
                            context.Session.SetString("num2ten", Numbers[num2 - 2]);
                            await _next.Invoke(context);
                        }
                    //}
                }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter");
            }
        }
    }
}
